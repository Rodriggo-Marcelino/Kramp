using Domain.Entity.Enum;
using Domain.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Generics;

[Table("user")]
public class UserGeneric : IUser
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string? Name { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column(TypeName = "varchar(50)")]
    public string? Username { get; set; }

    [Required]
    public string? PasswordHash { get; set; }

    [Required]
    public Document TypeDocument { get; set; }

    [Required]
    [StringLength(20)]
    public string? DocumentNumber { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}