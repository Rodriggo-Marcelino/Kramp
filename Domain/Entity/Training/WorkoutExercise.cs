using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Training
{
    [Table("workout_exercise")]
    public class WorkoutExercise : EntityGeneric
    {

        [Required]
        [Column("workout_id")]
        public Guid WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }

        [Required]
        [Column("exercise_id")]
        public Guid ExerciseId { get; set; }

        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }

        [Required]
        [Column("rest_time_in_seconds")]
        public int RestTimeInSeconds { get; set; }
        [Column("exercise_time_in_seconds")]
        public int ExerciseTimeInSeconds { get; set; }

        [Required]
        [Column("series")]
        public int Series { get; set; }

        [Required]
        [Column("repetitions")]
        public int Repetitions { get; set; }
    }
}
