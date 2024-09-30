using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using AutoMapper;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Templates
{
    public abstract class GetEntityByIdHandler<TEntity, TQuery, TViewModel, TRepository>(
        TRepository repository,
        IMapper mapper)
        : IRequestHandler<TQuery, ResponseBase<TViewModel>>
        where TEntity : EntityGeneric
        where TQuery : GetEntityByIdQuery<TViewModel>
        where TViewModel : GenericViewModelBase
        where TRepository : GenericRepository<TEntity>
    {
        public virtual async Task<ResponseBase<TViewModel>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(request.Id.Value);
        }

        public virtual async Task<ResponseBase<TViewModel>> GetByIdAsync(Guid id)
        {
            TEntity entity = await repository.GetByIdAsync(id);
            var viewModel = mapper.Map<TViewModel>(entity);
            return new ResponseBase<TViewModel>(new ResponseInfo(), viewModel);
        }
    }
}