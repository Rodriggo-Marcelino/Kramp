using Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Generics;

namespace Domain.Entity;

[Table("exercise")]
public class Exercise : TrainingGeneric
{
    public string? Foto { get; set; }
    public string? Video { get; set; }

    [Required]
    public Muscle TargetedMuscle { get; set; }
    public Muscle SynergistMuscle { get; set; }

    [Required]
    public int TempoDescansoEmSegundos { get; set; }
    public int TempoExercicioEmSegundos { get; set; }

    [Required]
    public int Series { get; set; }

    [Required]
    public int Repetitions { get; set; }
}