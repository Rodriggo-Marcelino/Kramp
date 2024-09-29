using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Queries
{
    public record GetEntityByIdQueryBase<TViewModel> : IRequest<ResponseBase<TViewModel>>
    {
        public Guid? Id { get; }

        public GetEntityByIdQueryBase(Guid id)
        {
            Id = id;
        }
    }
}
