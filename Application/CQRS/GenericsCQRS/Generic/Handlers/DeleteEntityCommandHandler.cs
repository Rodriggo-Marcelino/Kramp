using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public class DeleteEntityCommandHandler<TEntity, TCommand, TRepository> : IRequestHandler<TCommand, Unit>
        where TEntity : EntityGeneric
        where TCommand : DeleteEntityCommand<TEntity>
        where TRepository : GenericRepository<TEntity>
    {
        private readonly DeleteEntityTemplate<TEntity, TCommand, TRepository> _template;

        public DeleteEntityCommandHandler(DeleteEntityTemplate<TEntity, TCommand, TRepository> template)
        {
            _template = template;
        }

        public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await _template.DeleteByIdAsync(request.Id);
        }
    }
}
