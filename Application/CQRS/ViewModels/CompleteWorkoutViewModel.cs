using Domain.Entity.Enum;

namespace Application.CQRS.ViewModels;

public record CompleteWorkoutViewModel : GenericViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int SeriesCount { get; set; }
    public int RepetitionCount { get; set; }
    public Period? Period { get; set; }
    public List<Muscle>? TargetedMuscles { get; set; }
    public List<WorkoutExerciseViewModel>? Exercises { get; set; }
}