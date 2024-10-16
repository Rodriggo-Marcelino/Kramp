using System.Text.Json.Serialization;

namespace Application.CQRS.DTOs.Update
{
    public record UpdateExerciseInWorkoutDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public Guid ExerciseId { get; set; }
        public int RestTimeInSeconds { get; set; }
        public int ExerciseTimeInSeconds { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
    }
}