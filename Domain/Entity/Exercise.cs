using Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Generics;

namespace Domain.Entity;

[Table("exercise")]
public class Exercise : TrainingGeneric
{
    public string? Photo { get; set; }
    public string? Video { get; set; }

    [Required]
    public Muscle TargetedMuscle { get; set; }
    public Muscle SynergistMuscle { get; set; }

    [Required]
    public int RestTimeInSeconds { get; set; }
    public int ExerciseTimeInSeconds { get; set; }

    [Required]
    public int Series { get; set; }

    [Required]
    public int Repetitions { get; set; }
}