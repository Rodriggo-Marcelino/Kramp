using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using Domain.Entity;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Commands;

public record UpdatePlanCommand : IRequest<ResponseBase<PlanInfoViewModel>>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Workout>? Workouts { get; set; }
}