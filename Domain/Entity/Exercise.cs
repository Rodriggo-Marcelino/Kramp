using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Enum;

namespace Domain.Entity;

[Table("exercise")]
public class Exercise
{
    [Key]
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Foto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Video { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [StringLength(240)]
    [Column(TypeName = "varchar(240)")]
    public string? Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    public Muscle TargetedMuscle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Muscle SynergistMuscle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    public int TempoDescansoEmSegundos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int TempoExercicioEmSegundos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    public int Series { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    public int Repetitions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Timestamp]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}