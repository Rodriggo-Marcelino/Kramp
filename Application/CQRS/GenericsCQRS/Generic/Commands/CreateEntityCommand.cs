using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record CreateEntityCommand<TEntity, TDTO, TViewModel>(TDTO Data) : IRequest<ResponseBase<TViewModel>>
    {
        public TDTO Data { get; set; } = Data;
    }
}