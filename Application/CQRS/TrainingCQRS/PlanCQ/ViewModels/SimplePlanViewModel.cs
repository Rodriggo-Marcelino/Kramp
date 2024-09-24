namespace Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;

public record SimplePlanViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}