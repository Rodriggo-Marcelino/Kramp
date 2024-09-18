using Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Generics;

namespace Domain.Entity;

[Table("workout")]
public class Workout : TrainingGeneric
{
    [Required]
    public int SeriesCount { get; set; }
    
    [Required]
    public int RepetitionCount { get; set; }

    [Required]
    public Period Period { get; set; }
    
    [Required]
    public List<Muscle>? TargetedMuscles { get; set; }
    
    [Required]
    public ICollection<Exercise>? Exercises { get; set; }
    
    public ICollection<UserGeneric>? Users { get; set; } //Consumidores do Treino (Editar, Ver)
}