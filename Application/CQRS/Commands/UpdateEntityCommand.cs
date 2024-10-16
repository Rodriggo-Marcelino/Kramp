using Application.Response;
using MediatR;

namespace Application.CQRS.Commands
{
    public record UpdateEntityCommand<TEntity, TDTO, TViewModel>
        : IRequest<ResponseBase<IEnumerable<TViewModel>>>
    {
        public IEnumerable<TDTO>? DataList { get; set; }

        public UpdateEntityCommand(TDTO data)
        {
            DataList = new List<TDTO> { data };
        }

        public UpdateEntityCommand(IEnumerable<TDTO>? dataList)
        {
            DataList = dataList;
        }
    }
}