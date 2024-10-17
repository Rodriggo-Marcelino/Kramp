using Application.CQRS.Commands;
using Application.CQRS.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using Domain.Repository;
using MediatR;

namespace Application.CQRS.Templates;

public abstract class CreateEntityTemplate<TEntity, TCommand, TDTO, TViewModel, TRepository>(
    TRepository repository,
    IMapper mapper)
    : IRequestHandler<TCommand, ResponseBase<IEnumerable<TViewModel>>>
    where TEntity : EntityGeneric
    where TCommand : CreateEntityCommand<TEntity, TDTO, TViewModel>
    where TViewModel : GenericViewModel
    where TRepository : IRepository<TEntity>
    where TDTO : class
{
    private readonly TRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new NullReferenceException("request is null");
        }

        return await ExecuteAsync(request);
    }

    public async Task<ResponseBase<IEnumerable<TViewModel>>> ExecuteAsync(TCommand request)
    {

        ManipulateRequest(request);

        var entityList = MapCommandToEntity(request.DataList);

        ManipulateEntityBeforeSave(request.DataList, entityList);

        IEnumerable<TEntity>? savedEntityList = await SaveEntityAsync(entityList);

        ManipulateEntityAfterSave(request.DataList, savedEntityList);

        return CreateResponse(savedEntityList);
    }

    protected virtual void ManipulateRequest(TCommand request)
    {
    }

    protected virtual IEnumerable<TEntity> MapCommandToEntity(IEnumerable<TDTO>? requestList)
    {
        return _mapper.Map<IEnumerable<TEntity>>(requestList);
    }

    protected virtual void ManipulateEntityBeforeSave(IEnumerable<TDTO> request, IEnumerable<TEntity> entities)
    {
    }

    protected virtual Task<IEnumerable<TEntity?>?> SaveEntityAsync(IEnumerable<TEntity> entityList)
    {
        return _repository.AddAsync(entityList);
    }

    protected virtual void ManipulateEntityAfterSave(IEnumerable<TDTO> request, IEnumerable<TEntity> entities)
    {
    }

    protected virtual ResponseBase<IEnumerable<TViewModel>> CreateResponse(IEnumerable<TEntity>? entityList)
    {
        var viewModelList = _mapper.Map<IEnumerable<TViewModel>>(entityList);
        return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModelList);
    }
}