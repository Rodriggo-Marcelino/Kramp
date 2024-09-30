using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;

namespace Application.CQRS.TrainingCQRS.PlanCQ.ViewModels
{
    public record PlanWorkoutViewModel
    {
        public SimpleWorkoutViewModel Workout { get; set; }
    }
}