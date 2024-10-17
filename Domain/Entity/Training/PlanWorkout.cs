using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Training
{
    [Table("plan_workout")]
    public class PlanWorkout : EntityGeneric
    {

        [Required]
        [Column("plan_id")]
        public Guid PlanId { get; set; }

        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }

        [Required]
        [Column("workout_id")]
        public Guid WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }
    }
}
