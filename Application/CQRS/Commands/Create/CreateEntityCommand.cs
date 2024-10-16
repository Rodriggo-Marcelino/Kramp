using Application.Response;
using MediatR;

namespace Application.CQRS.Commands.Create
{
    public record CreateEntityCommand<TEntity, TDTO, TViewModel> : IRequest<ResponseBase<TViewModel>>
    {
        public TDTO? Data { get; set; }
        public IEnumerable<TDTO>? DataList { get; set; }

        public CreateEntityCommand(TDTO data)
        {
            Data = data;
            DataList = new List<TDTO> { data };
        }

        public CreateEntityCommand(IEnumerable<TDTO> dataList)
        {
            DataList = dataList;
        }
    }
}