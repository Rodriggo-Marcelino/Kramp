using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

public abstract class CreateEntityTemplate<TEntity, TCommand, TViewModel, TRepository>
    where TEntity : EntityGeneric
    where TCommand : IRequest<ResponseBase<TViewModel>>
    where TViewModel : GenericViewModel
    where TRepository : GenericRepository<TEntity>
{
    private readonly TRepository _repository;
    private readonly IMapper _mapper;

    public CreateEntityTemplate(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseBase<TViewModel>> ExecuteAsync(TCommand request)
    {
        ManipulateRequest(request);

        TEntity entity = MapCommandToEntity(request);

        ManipulateEntityBeforeSave(entity);

        await SaveEntityAsync(entity);

        ManipulateEntityAfterSave(entity);

        return CreateResponse(entity);
    }

    protected virtual void ManipulateRequest(TCommand request) { }

    protected virtual TEntity MapCommandToEntity(TCommand request)
    {
        return _mapper.Map<TEntity>(request);
    }

    protected virtual void ManipulateEntityBeforeSave(TEntity entity) { }

    protected virtual Task SaveEntityAsync(TEntity entity)
    {
        return _repository.AddAsync(entity);
    }

    protected virtual void ManipulateEntityAfterSave(TEntity entity) { }

    protected virtual ResponseBase<TViewModel> CreateResponse(TEntity entity)
    {
        var viewModel = _mapper.Map<TViewModel>(entity);
        return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel);
    }
}
