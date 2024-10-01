using System.Text.Json.Serialization;
using Domain.Entity.Enum;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.DTOs;

public record UpdateSimpleWorkoutDTO
{
    [JsonIgnore] 
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Period Period { get; set; }
}