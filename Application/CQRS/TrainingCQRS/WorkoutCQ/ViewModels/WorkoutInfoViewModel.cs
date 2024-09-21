using Domain.Entity.Enum;
using Domain.Entity.Training;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;

public class WorkoutInfoViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int SeriesCount { get; set; }
    public int RepetitionCount { get; set; }
    public Period? Period { get; set; }
    public List<Muscle>? TargetedMuscles { get; set; }
    //TODO: Classe de View model para exercise (e o mapper)
    public List<WorkoutExercise>? Exercises { get; set; }
}