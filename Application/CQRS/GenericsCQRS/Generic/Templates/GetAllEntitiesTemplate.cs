using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Templates
{
    public abstract class GetAllEntitiesTemplate<TEntity, TQuery, TViewModel, TRepository>
        : IRequestHandler<TQuery, ResponseBase<IEnumerable<TViewModel>>>
        where TEntity : EntityGeneric
        where TQuery : GetAllEntitiesQuery<TViewModel>
        where TViewModel : GenericViewModelBase
        where TRepository : GenericRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        protected GetAllEntitiesTemplate(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return await this.GetAllAsync();
        }

        public virtual async Task<ResponseBase<IEnumerable<TViewModel>>> GetAllAsync()
        {
            IEnumerable<TEntity> entities = await _repository.GetAllAsync();
            var viewModels = _mapper.Map<IEnumerable<TViewModel>>(entities);
            return new ResponseBase<IEnumerable<TViewModel>>(new ResponseInfo(), viewModels);
        }
    }
}
