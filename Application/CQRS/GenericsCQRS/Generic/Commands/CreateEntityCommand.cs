using Application.Response;
using MediatR;

public record CreateEntityCommand<TViewModel> : IRequest<ResponseBase<TViewModel>>
{
    public string? Name { get; set; }
}
