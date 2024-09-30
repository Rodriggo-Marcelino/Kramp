using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record DeleteEntityCommand<TEntity>(Guid Id) : IRequest<Unit>;
}