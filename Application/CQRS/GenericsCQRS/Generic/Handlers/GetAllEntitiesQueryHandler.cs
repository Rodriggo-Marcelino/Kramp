using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public class GetAllEntitiesQueryHandler<TEntity, TQuery, TViewModel, TRepository> : IRequestHandler<TQuery, ResponseBase<IEnumerable<TViewModel>>>
        where TEntity : EntityGeneric
        where TQuery : GetAllEntitiesQuery<TViewModel>
        where TViewModel : GenericViewModel
        where TRepository : GenericRepository<TEntity>
    {

        private readonly GetEntityTemplate<TEntity, TQuery, TViewModel, TRepository> _template;

        public GetAllEntitiesQueryHandler(GetEntityTemplate<TEntity, TQuery, TViewModel, TRepository> template)
        {
            _template = template;
        }

        public Task<ResponseBase<IEnumerable<TViewModel>>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return _template.GetAllAsync();
        }
    }
}
