using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Enum;
using Domain.Entity.Interfaces;

namespace Domain.Entity
{
    [Table("professional")]
    public class Professional : IUser
    {
        [Key]
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string? Surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? UserBio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public DateTime BirthDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Required]
        public string? Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string? PasswordHash { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public Document Document { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public Job Job { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Timestamp]
        public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? RefreshToken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? RefreshTokenExpiryTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
