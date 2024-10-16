namespace Application.CQRS.ViewModels
{
    public record PlanWorkoutViewModel
    {
        public SimpleWorkoutViewModel Workout { get; set; }
    }
}