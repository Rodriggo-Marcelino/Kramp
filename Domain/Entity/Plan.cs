using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Generics;

namespace Domain.Entity;

[Table("plan")]
public class Plan : TrainingGeneric
{
    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required]
    public ICollection<Workout>? Workouts { get; set; } //Exercicios do Plano

    public ICollection<UserGeneric>? Users { get; set; } //Consumidores do Plano (Editar, Ver)
}