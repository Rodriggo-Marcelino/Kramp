using Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

[Table("workout")]
public class Workout
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

    [Required]
    public List<Muscle> TargetedMuscles { get; set; }
    [Required]
    public ICollection<Exercise> Exercises { get; set; }

    [Required]
    public int SeriesCount { get; set; }
    [Required]
    public int RepetitionCount { get; set; }

    [Required]
    public Period Period { get; set; }

    public DateTime CreatedAt { get; set; }
}