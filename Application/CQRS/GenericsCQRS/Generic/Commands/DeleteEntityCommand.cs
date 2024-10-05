using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record DeleteEntityCommand<TEntity> : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public List<Guid>? Ids { get; set; }

        public DeleteEntityCommand(Guid id)
        {
            Id = id;
        }

        public DeleteEntityCommand(List<Guid> ids)
        {
            Ids = ids;
        }

    }
}