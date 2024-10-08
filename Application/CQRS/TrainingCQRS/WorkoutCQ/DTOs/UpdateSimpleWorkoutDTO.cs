using System.Text.Json.Serialization;
using Application.CQRS.GenericsCQRS.Generic.DTOs;
using Domain.Entity.Enum;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.DTOs;

public record UpdateSimpleWorkoutDTO : UpdateGenericDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Period Period { get; set; }
}