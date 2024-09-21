using Domain.Entity.Enum;
using Domain.Entity.Generics;
using Domain.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

[Table("workout")]
public class Workout : ITraining
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
    public int SeriesCount { get; set; }

    [Required]
    public int RepetitionCount { get; set; }

    [Required]
    public Period Period { get; set; }

    [Required]
    public List<Muscle>? TargetedMuscles { get; set; }

    // TODO: Aplicar o Required quando o Json for Controlado
    // [Required] 
    public ICollection<WorkoutExercise>? Exercises { get; set; }

    public ICollection<UserGeneric>? Users { get; set; } //Consumidores do Treino (Editar, Ver)
}