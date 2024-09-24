using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using MediatR;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;

public record CreateSimpleWorkoutCommand : IRequest<ResponseBase<SimpleWorkoutViewModel>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Period Period { get; set; }
}