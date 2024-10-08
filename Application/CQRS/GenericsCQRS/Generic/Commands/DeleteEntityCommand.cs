using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record DeleteEntityCommand<TEntity> : IRequest<Unit>
    {
        public IEnumerable<Guid>? Ids { get; set; }

        public DeleteEntityCommand(Guid id)
        {
            Ids = new List<Guid> { id };
        }

        public DeleteEntityCommand(IEnumerable<Guid> ids)
        {
            Ids = ids;
        }

    }
}