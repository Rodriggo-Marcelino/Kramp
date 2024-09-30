using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Commands
{
    public record UpdateEntityCommand<TEntity, TDTO, TViewModel>(Guid Id, TDTO Data)
        : IRequest<ResponseBase<TViewModel>>
    {
        public Guid Id { get; set; } = Id;
        public TDTO Data { get; set; } = Data;
    }
}