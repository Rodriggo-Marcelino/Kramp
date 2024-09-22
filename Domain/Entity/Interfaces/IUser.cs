using Domain.Entity.Enum;

namespace Domain.Entity.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        string? Name { get; set; }

        string? Username { get; set; }
        string? PasswordHash { get; set; }

        Document TypeDocument { get; set; }
        string? DocumentNumber { get; set; }

        DateTime CreatedAt { get; set; }
        string? RefreshToken { get; set; }
        DateTime? RefreshTokenExpiryTime { get; set; }

    }
}