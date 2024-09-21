using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("workout_exercise")]
    public class WorkoutExercise : TrainingGeneric
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ExerciseId { get; set; }

        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }

        [Required]
        public Guid WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }

        [Required]
        public int RestTimeInSeconds { get; set; }
        public int ExerciseTimeInSeconds { get; set; }

        [Required]
        public int Series { get; set; }

        [Required]
        public int Repetitions { get; set; }
    }
}
