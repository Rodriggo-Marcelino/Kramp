using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using Domain.Entity;
using MediatR;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Commands;

public record CreatePlanCommand : IRequest<ResponseBase<PlanInfoViewModel>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Workout>? Workouts { get; set; }
}