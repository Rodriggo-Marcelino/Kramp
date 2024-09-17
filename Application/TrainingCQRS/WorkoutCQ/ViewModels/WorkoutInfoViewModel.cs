using Domain.Entity;

namespace Application.WorkoutCQ.ViewModels;

public class WorkoutInfoViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int SeriesCount { get; set; }
    public int RepetitionCount { get; set; }
    public string? Period { get; set; }
    public ICollection<string>? TargetedMuscles { get; set; }
    public ICollection<Exercise> Exercises { get; set; }
}