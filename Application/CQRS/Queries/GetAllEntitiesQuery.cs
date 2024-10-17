using Application.Response;
using MediatR;

namespace Application.CQRS.Queries
{
    public record GetAllEntitiesQuery<TViewModel> : IRequest<ResponseBase<IEnumerable<TViewModel>>>
    {
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }

        public GetAllEntitiesQuery()
        {
        }

        public GetAllEntitiesQuery(int? pageNumber, int? pageSize)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
        }
    }
}