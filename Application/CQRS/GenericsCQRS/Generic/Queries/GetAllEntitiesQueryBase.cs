using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Queries
{
    public record GetAllEntitiesQueryBase<TViewModel> : IRequest<ResponseBase<IEnumerable<TViewModel>>>
    {
    }
}
