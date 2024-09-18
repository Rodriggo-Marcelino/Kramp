using System.Text.Json.Serialization;
using Domain.Entity;
using Domain.Entity.Enum;

namespace Application.WorkoutCQ.Commands;

public class UpdateWorkoutCommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Descritption {get; set;}
    public List<Muscle>? TargetedMuscles { get; set; }
    public ICollection<Exercise>? Exercises { get; set; }
}