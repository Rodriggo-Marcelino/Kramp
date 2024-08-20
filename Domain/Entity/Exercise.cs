using Domain.Entity.Enum;

namespace Domain.Entity;

public class Exercise
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Foto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Video { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public Muscle TargetedMuscle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Muscle SynergistMuscle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public int TempoDescansoEmSegundos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int TempoExercicioEmSegundos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Series { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Repetitions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}