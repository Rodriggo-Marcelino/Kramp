using Application.CQRS.GenericsCQRS.Generic.Commands;
using Domain.Entity.Generics;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.GenericsCQRS.Generic.Templates
{
    public abstract class DeleteEntityTemplate<TEntity, TCommand, TRepository>
        where TEntity : EntityGeneric
        where TCommand : DeleteEntityCommand<TEntity>
        where TRepository : GenericRepository<TEntity>
    {
        private readonly TRepository _repository;

        public DeleteEntityTemplate(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> DeleteByIdAsync(Guid id)
        {
            TEntity entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
            return Unit.Value;
        }
    }
}
