using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record CreateEntityCommand<TEntity, TDTO, TViewModel> : IRequest<ResponseBase<TViewModel>>
    {
        public TDTO Data { get; set; }

        public CreateEntityCommand(TDTO data)
        {
            Data = data;
        }
    }
}