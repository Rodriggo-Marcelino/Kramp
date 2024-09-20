using Domain.Entity;
using Domain.Entity.Enum;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;

public class CreateWorkoutCommand
{
    public string? Name { get; set; }
    public string? Descritption { get; set; }
    public List<Muscle>? TargetedMuscles { get; set; }
    public ICollection<Exercise>? Exercises { get; set; }
}