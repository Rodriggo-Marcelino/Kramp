using Domain.Entity.Enum;
using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Training;

[Table("exercise")]
public class Exercise : TrainingGeneric
{

    [Column("photo")]
    public string? Photo { get; set; }
    [Column("video")]
    public string? Video { get; set; }

    [Required]
    [Column("targeted_muscle")]
    public Muscle TargetedMuscle { get; set; }
    [Column("synergist_muscle")]
    public Muscle SynergistMuscle { get; set; }
}