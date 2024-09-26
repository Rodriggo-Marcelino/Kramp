using Application.Response;
using MediatR;

public record CreateEntityCommand<TEntity, TViewModel> : IRequest<ResponseBase<TViewModel>>
{
}
