using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Interfaces;

namespace Domain.Entity.Generics;

[NotMapped]
public class TrainingGeneric : ITraining
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
    
    public DateTime CreatedAt { get; set; }
}