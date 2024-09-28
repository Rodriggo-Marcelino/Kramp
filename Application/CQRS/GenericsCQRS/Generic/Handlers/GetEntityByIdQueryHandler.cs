using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public class GetEntityByIdQueryHandler<TEntity, TQuery, TViewModel, TRepository> : IRequestHandler<TQuery, ResponseBase<TViewModel>>
        where TEntity : EntityGeneric
        where TQuery : GetEntityByIdQuery<TViewModel>
        where TViewModel : GenericViewModel
        where TRepository : GenericRepository<TEntity>
    {
        private readonly GetEntityByIdTemplate<TEntity, TQuery, TViewModel, TRepository> _template;

        public GetEntityByIdQueryHandler(GetEntityByIdTemplate<TEntity, TQuery, TViewModel, TRepository> template)
        {
            _template = template;
        }

        public async Task<ResponseBase<TViewModel>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return await _template.GetByIdAsync(request.Id.Value);
        }
    }
}
