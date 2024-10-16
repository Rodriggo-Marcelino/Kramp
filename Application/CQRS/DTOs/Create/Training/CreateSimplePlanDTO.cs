namespace Application.CQRS.DTOs.Create.Training
{
    public record CreateSimplePlanDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
