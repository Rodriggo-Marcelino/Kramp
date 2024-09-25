using Domain.Entity.Enum;
using Domain.Entity.Generics;
using Domain.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Training;

[Table("workout")]
public class Workout : TrainingGeneric, ITraining
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

    public int SeriesCount { get; set; }

    public int RepetitionCount { get; set; }

    [Required]
    public Period Period { get; set; }

    public List<Muscle>? TargetedMuscles { get; set; }

    public ICollection<WorkoutExercise>? Exercises { get; set; }

    public ICollection<UserGeneric>? Users { get; set; } //Consumidores do Treino (Editar, Ver)
}