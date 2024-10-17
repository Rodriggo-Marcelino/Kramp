using Application.Response;
using MediatR;

namespace Application.CQRS.Commands
{
    public record CreateEntityCommand<TEntity, TDTO, TViewModel> : IRequest<ResponseBase<IEnumerable<TViewModel>>>
    {
        public IEnumerable<TDTO>? DataList { get; set; }

        public CreateEntityCommand(TDTO data)
        {
            DataList = new List<TDTO> { data };
        }

        public CreateEntityCommand(IEnumerable<TDTO> dataList)
        {
            DataList = dataList;
        }
    }
}