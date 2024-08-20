using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Enum;

namespace Domain.Entity;

[Table("workout")]
public class Workout
{
    [Key]
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [StringLength(240)]
    [Column(TypeName = "varchar(240)")]
    public string? Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    public List<Muscle> TargetedMuscles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [Required]
    public ICollection<Exercise> Exercises { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    public int SeriesCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [Required]
    public int RepetitionCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    public Period Period { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [Timestamp]
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}