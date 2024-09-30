using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Commands
{
    public record UpdateWorkoutsInPlanCommand : IRequest<ResponseBase<PlanWorkoutViewModel>>
    {
        [JsonIgnore] public Guid Id { get; set; }
        [JsonIgnore] public Guid PlanId { get; set; }

        public Guid WorkoutId { get; set; }
    }
}