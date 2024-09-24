using Domain.Entity.Generics;
using Domain.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Training;

[Table("training_plan")]
public class Plan : TrainingGeneric, ITraining
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string? Name { get; set; }

    [StringLength(240)]
    [Column(TypeName = "varchar(240)")]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    public ICollection<PlanWorkout>? Workouts { get; set; } //Treinos do Plano

    public ICollection<UserGeneric>? Users { get; set; } //Consumidores do Plano (Editar, Ver)
}