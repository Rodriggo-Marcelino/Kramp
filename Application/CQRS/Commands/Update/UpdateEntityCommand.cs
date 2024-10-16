using Application.Response;
using MediatR;

namespace Application.CQRS.Commands.Update
{
    public record UpdateEntityCommand<TEntity, TDTO, TViewModel>
        : IRequest<ResponseBase<TViewModel>>
    {
        public Guid Id { get; set; }
        public TDTO? Data { get; set; }
        public IEnumerable<TDTO>? DataList { get; set; }

        public UpdateEntityCommand(Guid id, TDTO data)
        {
            Id = id;
            Data = data;
            DataList = new List<TDTO> { data };
        }

        public UpdateEntityCommand(Guid id, List<TDTO> dataList)
        {
            Id = id;
            DataList = dataList;
        }
    }
}