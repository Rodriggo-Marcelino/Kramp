using Domain.Entity.Enum;
using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Training;

[Table("workout")]
public class Workout : TrainingGeneric
{

    [Column("series_count")]
    public int SeriesCount { get; set; }

    [Column("repetition_count")]
    public int RepetitionCount { get; set; }

    [Required]
    [Column("period")]
    public Period Period { get; set; }

    [Column("targeted_muscles")]
    public List<Muscle>? TargetedMuscles { get; set; }

    public ICollection<WorkoutExercise>? Exercises { get; set; }

    public ICollection<UserGeneric>? Users { get; set; } //Consumidores do Treino (Editar, Ver)
}