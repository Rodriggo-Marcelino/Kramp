using Application.CQRS.GenericsCQRS.Generic.Commands;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public abstract class DeleteEntityHandler<TEntity, TCommand, TRepository>
        (TRepository repository)
        : IRequestHandler<TCommand, Unit>
        where TEntity : EntityGeneric
        where TCommand : DeleteEntityCommand<TEntity>
        where TRepository : GenericRepository<TEntity>
    {
        public virtual async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await this.DeleteByIdAsync(request.Id);
        }

        public async Task<Unit> DeleteByIdAsync(Guid id)
        {
            TEntity? entity = await repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} not found");
            }

            if (entity != null)
            {
                await repository.DeleteAsync(entity);
            }

            return Unit.Value;
        }
    }
}