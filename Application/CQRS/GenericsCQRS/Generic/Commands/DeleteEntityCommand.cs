using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record DeleteEntityCommand<TEntity> : IRequest<Unit>
    {
        public Guid Id { get; }

        public DeleteEntityCommand(Guid id)
        {
            Id = id;
        }
    }
}