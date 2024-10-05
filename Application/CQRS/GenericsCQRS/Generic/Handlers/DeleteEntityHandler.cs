using Application.CQRS.GenericsCQRS.Generic.Commands;
using Domain.Entity.Generics;
using Domain.Repository;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Handlers
{
    public abstract class DeleteEntityHandler<TEntity, TCommand, TRepository>
        (TRepository repository)
        : IRequestHandler<TCommand, Unit>
        where TEntity : EntityGeneric
        where TCommand : DeleteEntityCommand<TEntity>
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository = repository;
        public virtual async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await this.DeleteByIdAsync(request.Id);
        }

        public async Task<Unit> DeleteByIdAsync(Guid id)
        {
            TEntity? entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} not found");
            }

            await _repository.DeleteAsync(entity);

            return Unit.Value;
        }
    }
}