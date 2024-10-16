using Application.CQRS.ViewModels;
using Application.Response;
using MediatR;

namespace Application.CQRS.Commands.Create;

public record CreateSimplePlanCommand : IRequest<ResponseBase<SimplePlanViewModel>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}