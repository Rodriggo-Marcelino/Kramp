using Domain.Entity;
using Domain.Entity.Enum;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;

public class WorkoutInfoViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int SeriesCount { get; set; }
    public int RepetitionCount { get; set; }
    public string? Period { get; set; }
    public List<Muscle>? TargetedMuscles { get; set; }
    //TODO: Classe de View model para exercise (e o mapper)
    public List<Exercise>? Exercises { get; set; }
}