using Application.WorkoutCQ.ViewModels;
using Domain.Entity;

namespace Application.PlanCQ.ViewModels;

public class PlanInfoViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<WorkoutInfoViewModel>? Workouts { get; set; }
}