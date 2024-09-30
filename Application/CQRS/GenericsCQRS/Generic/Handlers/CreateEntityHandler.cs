using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Templates;

public abstract class CreateEntityHandler<TEntity, TCommand, TDTO, TViewModel, TRepository>(
    TRepository repository,
    IMapper mapper)
    : IRequestHandler<TCommand, ResponseBase<TViewModel>>
    where TEntity : EntityGeneric
    where TCommand : CreateEntityCommand<TEntity, TDTO, TViewModel>
    where TViewModel : GenericViewModelBase
    where TRepository : GenericRepository<TEntity>
    where TDTO : class
{
    public virtual async Task<ResponseBase<TViewModel>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        return await this.ExecuteAsync(request);
    }

    public async Task<ResponseBase<TViewModel>> ExecuteAsync(TCommand request)
    {
        ManipulateRequest(request);

        TEntity entity = MapCommandToEntity(request.Data);

        ManipulateEntityBeforeSave(request.Data, entity);

        await SaveEntityAsync(entity);

        ManipulateEntityAfterSave(entity);

        return CreateResponse(entity);
    }

    protected virtual void ManipulateRequest(TCommand request)
    {
    }

    protected virtual TEntity MapCommandToEntity(TDTO request)
    {
        return mapper.Map<TEntity>(request);
    }

    protected virtual void ManipulateEntityBeforeSave(TDTO request, TEntity entity)
    {
    }

    protected virtual Task SaveEntityAsync(TEntity entity)
    {
        return repository.AddAsync(entity);
    }

    protected virtual void ManipulateEntityAfterSave(TEntity entity)
    {
    }

    protected virtual ResponseBase<TViewModel> CreateResponse(TEntity entity)
    {
        var viewModel = mapper.Map<TViewModel>(entity);
        return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel);
    }
}