using Domain.Entity.Enum;

namespace Domain.Entity;

public class Workout
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public List<Muscle> TargetedMuscles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ICollection<Exercise> Exercises { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public int SeriesCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int RepetitionCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public Period Period { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}