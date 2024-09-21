using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("plan_workout")]
    public class PlanWorkout : TrainingGeneric
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid PlanId { get; set; }

        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }

        [Required]
        public Guid WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }
    }
}
