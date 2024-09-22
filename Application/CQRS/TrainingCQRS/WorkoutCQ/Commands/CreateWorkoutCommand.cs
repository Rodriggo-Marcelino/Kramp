using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using MediatR;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;

public record CreateWorkoutCommand : IRequest<ResponseBase<WorkoutInfoViewModel>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Period Period { get; set; }
    public IEnumerable<Guid>? Exercises { get; set; }
}