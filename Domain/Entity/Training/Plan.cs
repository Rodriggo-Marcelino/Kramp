using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Training;

[Table("training_plan")]
public class Plan : TrainingGeneric
{

    [Required]
    [DataType(DataType.Date)]
    [Column("start_date")]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column("end_date")]
    public DateTime EndDate { get; set; }

    public ICollection<PlanWorkout>? Workouts { get; set; } //Treinos do Plano

    public ICollection<UserGeneric>? Users { get; set; } //Consumidores do Plano (Editar, Ver)
}