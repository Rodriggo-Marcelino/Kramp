using Application.CQRS.Commands.Delete;
using Domain.Entity.Generics;
using Domain.Repository;
using MediatR;

namespace Application.CQRS.Templates
{
    public abstract class DeleteEntityTemplate<TEntity, TCommand, TRepository>
        (TRepository repository)
        : IRequestHandler<TCommand, Unit>
        where TEntity : EntityGeneric
        where TCommand : DeleteEntityCommand<TEntity>
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository = repository;
        public virtual async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await DeleteByIdAsync(request);
        }

        public async Task<Unit> DeleteByIdAsync(TCommand request)
        {
            var ids = request.Ids;

            IEnumerable<TEntity?> entityList = await _repository.FindAllByIdAsync(ids);

            await _repository.DeleteAsync(entityList);

            return Unit.Value;
        }
    }
}