using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record CreateEntityCommand<TEntity, TViewModel> : IRequest<ResponseBase<TViewModel>>
    {
        public CreateEntityCommand()
        {

        }
    }
}
