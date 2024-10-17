using Domain.Entity.Enum;

namespace Application.CQRS.DTOs.Create.Training;

public record CreateSimpleWorkoutDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Period Period { get; set; }
}