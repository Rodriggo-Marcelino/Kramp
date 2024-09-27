using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Queries
{
    public record GetEntitiesByIdQuery<TViewModel> : IRequest<ResponseBase<TViewModel>>
    {
        public Guid? Id { get; }

        public GetEntitiesByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
