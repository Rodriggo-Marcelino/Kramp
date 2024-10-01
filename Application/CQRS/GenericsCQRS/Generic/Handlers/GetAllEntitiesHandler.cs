using System.Linq.Expressions;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public abstract class GetAllEntitiesHandler<TEntity, TQuery, TViewModel, TRepository>(
        TRepository repository,
        IMapper mapper)
        : IRequestHandler<TQuery, ResponseBase<IEnumerable<TViewModel>>>
        where TEntity : EntityGeneric
        where TQuery : GetAllEntitiesQuery<TViewModel>
        where TViewModel : GenericViewModelBase
        where TRepository : GenericRepository<TEntity>
    {
        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> Handle(TQuery request,
            CancellationToken cancellationToken)
        {
            return await this.GetAllAsync();
        }

        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> GetAllAsync()
        {
            IEnumerable<TEntity> entities = await repository.GetAllAsync();
            var viewModels = mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }
        
        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> GetAllAsync
            (Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            IEnumerable<TEntity> entities = await repository.GetAllAsync(orderBy);
            var viewModels = mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }
        
        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> GetAllAsync
            (Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int page, int pageSize)
        {
            IEnumerable<TEntity> entities = await repository.GetAllAsync(orderBy, page, pageSize);
            var viewModels = mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }
        
        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = await repository.FindAllAsync(predicate);
            var viewModels = mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }
        
        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> FindAllByIdAsync(IEnumerable<Guid> ids)
        {
            IEnumerable<TEntity> entities = await repository.FindAllByIdAsync(ids);
            var viewModels = mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }
    }
}