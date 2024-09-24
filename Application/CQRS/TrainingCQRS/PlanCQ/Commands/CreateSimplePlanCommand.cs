using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Commands;

public record CreateSimplePlanCommand : IRequest<ResponseBase<SimplePlanViewModel>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}