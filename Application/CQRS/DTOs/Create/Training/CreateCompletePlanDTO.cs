namespace Application.CQRS.DTOs.Create
{
    public record CreateCompletePlanDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<AddWorkoutToPlanDTO>? Workouts { get; set; }
    }
}
