using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record CreateEntityCommandBase<TEntity, TDTO, TViewModel> : IRequest<ResponseBase<TViewModel>>
    {

        public TDTO Data { get; set; }

        public CreateEntityCommandBase(TDTO data)
        {
            Data = data;
        }
    }
}
