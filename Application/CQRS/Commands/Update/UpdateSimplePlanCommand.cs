using Application.CQRS.ViewModels;
using Application.Response;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.Commands.Update;

public record UpdateSimplePlanCommand : IRequest<ResponseBase<SimplePlanViewModel>>
{
    [JsonIgnore] public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}