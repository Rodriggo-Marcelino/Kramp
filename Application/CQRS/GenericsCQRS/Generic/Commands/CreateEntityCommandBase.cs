using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record CreateEntityCommandBase<TEntity, TViewModel> : IRequest<ResponseBase<TViewModel>>
    {
    }
}
