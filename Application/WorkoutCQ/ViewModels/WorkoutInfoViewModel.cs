using Domain.Entity;

namespace Application.WorkoutCQ.ViewModels;

public class WorkoutInfoViewModel
{
    public ICollection<Exercise> Exercises { get; set; }
}