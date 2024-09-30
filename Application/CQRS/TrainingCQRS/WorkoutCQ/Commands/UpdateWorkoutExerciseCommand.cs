using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Commands
{
    public record UpdateWorkoutExerciseCommand : IRequest<ResponseBase<WorkoutExerciseViewModel?>>
    {
        [JsonIgnore] public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public Guid ExerciseId { get; set; }
        public int RestTimeInSeconds { get; set; }
        public int ExerciseTimeInSeconds { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
    }
}