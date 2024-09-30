using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Queries
{
    public record GetEntityByIdQuery<TViewModel> : IRequest<ResponseBase<TViewModel>>
    {
        public Guid? Id { get; }

        public GetEntityByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}