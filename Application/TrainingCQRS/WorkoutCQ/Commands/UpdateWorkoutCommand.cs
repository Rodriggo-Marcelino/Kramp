using System.Text.Json.Serialization;

namespace Application.WorkoutCQ.Commands;

public class UpdateWorkoutCommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
}