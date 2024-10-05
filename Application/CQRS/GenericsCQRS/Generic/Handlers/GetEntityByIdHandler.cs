using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using Domain.Repository;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public abstract class GetEntityByIdHandler<TEntity, TQuery, TViewModel, TRepository>(
        TRepository repository,
        IMapper mapper)
        : IRequestHandler<TQuery, ResponseBase<TViewModel>>
        where TEntity : EntityGeneric
        where TQuery : GetEntityByIdQuery<TViewModel>
        where TViewModel : GenericViewModel
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public virtual async Task<ResponseBase<TViewModel>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(request.Id.Value);
        }

        public virtual async Task<ResponseBase<TViewModel>> GetByIdAsync(Guid id)
        {
            TEntity? entity = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<TViewModel>(entity);
            return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel);
        }
    }
}