namespace Domain.Entity.Interfaces;

public interface ITraining
{
    Guid Id { get; set; }

    string? Name { get; set; }

    string? Description { get; set; }

    DateTime CreatedAt { get; set; }

    DateTime UpdatedAt { get; set; }
}