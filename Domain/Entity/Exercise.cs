using Domain.Entity.Enum;
using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

[Table("exercise")]
public class Exercise : TrainingGeneric
{
    public string? Photo { get; set; }
    public string? Video { get; set; }

    [Required]
    public Muscle TargetedMuscle { get; set; }
    public Muscle SynergistMuscle { get; set; }
}