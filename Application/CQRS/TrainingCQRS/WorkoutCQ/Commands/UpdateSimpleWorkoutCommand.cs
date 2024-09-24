using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;

public record UpdateSimpleWorkoutCommand : IRequest<ResponseBase<SimpleWorkoutViewModel>>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Period Period { get; set; }
}