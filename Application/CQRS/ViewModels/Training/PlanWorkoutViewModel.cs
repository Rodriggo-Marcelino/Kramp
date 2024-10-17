namespace Application.CQRS.ViewModels.Training
{
    public record PlanWorkoutViewModel : GenericViewModel
    {
        public Guid PlanId { get; set; }
        public Guid WorkoutId { get; set; }
    }
}