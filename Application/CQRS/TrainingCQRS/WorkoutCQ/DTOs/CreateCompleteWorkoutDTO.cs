using Domain.Entity.Enum;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.DTOs;

public record CreateCompleteWorkoutDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Period Period { get; set; }
    public ICollection<Guid>? Exercises { get; set; }
}