namespace Application.CQRS.ViewModels.Training
{
    public record PlanWorkoutViewModel : GenericViewModel
    {
        public SimpleWorkoutViewModel Workout { get; set; }
    }
}