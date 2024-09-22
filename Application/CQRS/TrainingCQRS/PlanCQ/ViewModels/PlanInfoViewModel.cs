namespace Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;

public class PlanInfoViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    //TODO: Classe de View model para workout (e o mapper)
    //public List<Workout>? Workouts { get; set; }
}