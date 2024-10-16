using Application.CQRS.Queries;
using Application.CQRS.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using Domain.Repository;
using MediatR;
using System.Linq.Expressions;

namespace Application.CQRS.Templates
{
    public abstract class GetAllEntitiesTemplate<TEntity, TQuery, TViewModel, TRepository>(
        TRepository repository,
        IMapper mapper)
        : IRequestHandler<TQuery, ResponseBase<IEnumerable<TViewModel>>>
        where TEntity : EntityGeneric
        where TQuery : GetAllEntitiesQuery<TViewModel>
        where TViewModel : GenericViewModel
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> Handle(TQuery request,
            CancellationToken cancellationToken)
        {
            return await GetAllAsync();
        }

        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> GetAllAsync()
        {
            IEnumerable<TEntity?> entities = await _repository.GetAllAsync();
            var viewModels = _mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }

        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> GetAllAsync
            (Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            IEnumerable<TEntity?> entities = await _repository.GetAllAsync(orderBy);
            var viewModels = _mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }

        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> GetAllAsync
            (Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int page, int pageSize)
        {
            IEnumerable<TEntity?> entities = await _repository.GetAllAsync(orderBy, page, pageSize);
            var viewModels = _mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }

        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity?> entities = await _repository.FindAllAsync(predicate);
            var viewModels = _mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }

        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> FindAllByIdAsync(IEnumerable<Guid> ids)
        {
            IEnumerable<TEntity?> entities = await _repository.FindAllByIdAsync(ids);
            var viewModels = _mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }
    }
}