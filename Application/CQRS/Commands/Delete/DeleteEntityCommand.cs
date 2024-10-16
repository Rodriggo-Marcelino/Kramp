using MediatR;

namespace Application.CQRS.Commands.Delete
{
    public record DeleteEntityCommand<TEntity> : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public IEnumerable<Guid>? Ids { get; set; }

        public DeleteEntityCommand(Guid id)
        {
            Id = id;
            Ids = new List<Guid> { id };
        }

        public DeleteEntityCommand(List<Guid> ids)
        {
            Ids = ids;
        }

    }
}