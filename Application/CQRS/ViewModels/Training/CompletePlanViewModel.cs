namespace Application.CQRS.ViewModels.Training
{
    public record CompletePlanViewModel : GenericViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SimpleWorkoutViewModel>? Workouts { get; set; }
    }
}