using Domain.Entity.Enum;

namespace Application.CQRS.DTOs.Update.Training;

public record UpdateSimpleWorkoutDTO : UpdateGenericDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Period Period { get; set; }
}