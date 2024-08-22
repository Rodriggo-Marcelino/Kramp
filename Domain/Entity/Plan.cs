using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Interfaces;

namespace Domain.Entity;

[Table("plan")]
public class Plan
{
    [Key]
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [StringLength(240)]
    [Column(TypeName = "varchar(240)")]
    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    [Required]
    public ICollection<Workout> Workouts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public ICollection<Member> Member { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

//Todo: Adicionar IUser