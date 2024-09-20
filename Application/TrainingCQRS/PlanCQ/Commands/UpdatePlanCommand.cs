using Domain.Entity;
using System.Text.Json.Serialization;

namespace Application.PlanCQ.Commands;

public class UpdatePlanCommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Workout>? Workouts { get; set; }
}