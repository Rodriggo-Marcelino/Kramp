using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using Domain.Repository;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers;

public abstract class CreateEntityHandler<TEntity, TCommand, TDTO, TViewModel, TRepository>(
    TRepository repository,
    IMapper mapper)
    : IRequestHandler<TCommand, ResponseBase<TViewModel>>
    where TEntity : EntityGeneric
    where TCommand : CreateEntityCommand<TEntity, TDTO, TViewModel>
    where TViewModel : GenericViewModel
    where TRepository : IRepository<TEntity>
    where TDTO : class
{
    private readonly TRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public virtual async Task<ResponseBase<TViewModel>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        return await ExecuteAsync(request);
    }

    public async Task<ResponseBase<TViewModel>> ExecuteAsync(TCommand request)
    {
        ManipulateRequest(request);

        TEntity entity = MapCommandToEntity(request.Data);

        ManipulateEntityBeforeSave(request.Data, entity);

        TEntity? savedEntity = await SaveEntityAsync(entity);

        ManipulateEntityAfterSave(request.Data, savedEntity);

        return CreateResponse(savedEntity);
    }

    protected virtual void ManipulateRequest(TCommand request)
    {
    }

    protected virtual TEntity MapCommandToEntity(TDTO request)
    {
        return _mapper.Map<TEntity>(request);
    }

    protected virtual void ManipulateEntityBeforeSave(TDTO data, TEntity entity)
    {
    }

    protected virtual Task<TEntity?> SaveEntityAsync(TEntity entity)
    {
        return _repository.AddAsync(entity);
    }

    protected virtual void ManipulateEntityAfterSave(TDTO data, TEntity? entity)
    {
    }

    protected virtual ResponseBase<TViewModel> CreateResponse(TEntity? entity)
    {
        var viewModel = _mapper.Map<TViewModel>(entity);
        return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel);
    }
}