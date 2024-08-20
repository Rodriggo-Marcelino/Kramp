using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Interfaces;

namespace Domain.Entity;

[Table("plan")]
public class Plan
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public DateTime StartDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime EndDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public ICollection<Workout> workouts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public IUser Member { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IUser Creator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}