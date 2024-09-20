using Domain.Entity;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Commands;

public class CreatePlanCommand
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Workout>? Workouts { get; set; }
}