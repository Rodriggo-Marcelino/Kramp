using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record DeleteEntityCommandBase<TEntity> : IRequest<Unit>
    {
        public Guid Id { get; }

        public DeleteEntityCommandBase(Guid id)
        {
            Id = id;
        }
    }
}
