using System.Text.Json.Serialization;

namespace Application.CQRS.DTOs.Create;

public record AddExerciseToWorkoutDTO
{
    [JsonIgnore]
    public Guid WorkoutId { get; set; }
    public Guid ExerciseId { get; set; }
    public int RestTimeInSeconds { get; set; }
    public int ExerciseTimeInSeconds { get; set; }
    public int Series { get; set; }
    public int Repetitions { get; set; }
}