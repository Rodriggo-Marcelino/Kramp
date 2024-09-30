using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.Generic.Queries
{
    public record GetAllEntitiesQuery<TViewModel> : IRequest<ResponseBase<IEnumerable<TViewModel>>>
    {
    }
}