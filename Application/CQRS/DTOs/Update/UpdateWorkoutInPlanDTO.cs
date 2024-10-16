using System.Text.Json.Serialization;

namespace Application.CQRS.DTOs.Update
{
    public record UpdateWorkoutInPlanDTO : UpdateGenericDTO
    {
        [JsonIgnore]
        public Guid PlanId { get; set; }

        public Guid WorkoutId { get; set; }
    }
}
