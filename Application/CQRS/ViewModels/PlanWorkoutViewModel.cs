namespace Application.CQRS.ViewModels
{
    public record PlanWorkoutViewModel : GenericViewModel
    {
        public SimpleWorkoutViewModel Workout { get; set; }
    }
}