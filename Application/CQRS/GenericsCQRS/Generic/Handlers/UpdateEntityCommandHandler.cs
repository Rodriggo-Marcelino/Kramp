using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Application.Response;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public class UpdateEntityCommandHandler<TEntity, TCommand, TViewModel, TRepository> : IRequestHandler<TCommand, ResponseBase<TViewModel>>
        where TEntity : EntityGeneric
        where TCommand : UpdateEntityCommand<TEntity, TViewModel>
        where TViewModel : GenericViewModel
        where TRepository : GenericRepository<TEntity>
    {
        private readonly UpdateEntityTemplate<TEntity, TCommand, TViewModel, TRepository> _template;

        public UpdateEntityCommandHandler(UpdateEntityTemplate<TEntity, TCommand, TViewModel, TRepository> template)
        {
            _template = template;
        }
        public async Task<ResponseBase<TViewModel>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await _template.ExecuteAsync(request);
        }
    }
}
