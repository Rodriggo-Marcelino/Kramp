using Domain.Entity.Enum;
using Domain.Entity.Generics;
using Domain.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Training;

[Table("exercise")]
public class Exercise : TrainingGeneric, ITraining
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string? Name { get; set; }

    [StringLength(240)]
    [Column(TypeName = "varchar(240)")]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Photo { get; set; }
    public string? Video { get; set; }

    [Required]
    public Muscle TargetedMuscle { get; set; }
    public Muscle SynergistMuscle { get; set; }
}