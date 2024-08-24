using Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

[Table("exercise")]
public class Exercise
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Foto { get; set; }
    public string? Video { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string? Name { get; set; }

    [StringLength(240)]
    [Column(TypeName = "varchar(240)")]
    public string? Description { get; set; }

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

    public DateTime CreatedAt { get; set; }
}