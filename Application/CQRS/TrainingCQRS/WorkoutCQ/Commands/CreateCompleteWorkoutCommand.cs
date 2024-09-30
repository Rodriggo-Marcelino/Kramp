using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using MediatR;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Commands
{
    public record CreateCompleteWorkoutCommand : IRequest<ResponseBase<CompleteWorkoutViewModel>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Period Period { get; set; }
        public ICollection<Guid>? Exercises { get; set; }
    }
}