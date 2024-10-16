using Domain.Entity.Enum;

namespace Application.CQRS.DTOs.Create;

public record CreateCompleteWorkoutDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Period Period { get; set; }
    public IEnumerable<AddExerciseToWorkoutDTO>? Exercises { get; set; }
}