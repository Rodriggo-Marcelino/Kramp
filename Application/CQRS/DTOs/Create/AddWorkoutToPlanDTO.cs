using System.Text.Json.Serialization;

namespace Application.CQRS.DTOs.Create
{
    public record AddWorkoutToPlanDTO
    {
        [JsonIgnore]
        public Guid PlanId { get; set; }
        public Guid WorkoutId { get; set; }
    }
}
