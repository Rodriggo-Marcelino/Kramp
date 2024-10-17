using Domain.Entity.Enum;
using Domain.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Generics;

[Table("users")]
public class UserGeneric : EntityGeneric, IUser
{

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column("name", TypeName = "varchar(50)")]
    public string? Name { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Column("username", TypeName = "varchar(50)")]
    public string? Username { get; set; }

    [Required]
    [Column("password_hash")]
    public string? PasswordHash { get; set; }

    [Required]
    [Column("type_document")]
    public Document TypeDocument { get; set; }

    [Required]
    [StringLength(20)]
    [Column("document_number", TypeName = "varchar(20)")]
    public string? DocumentNumber { get; set; }
    [Column("refresh_token")]
    public string? RefreshToken { get; set; }
    [Column("refresh_token_expiry_time")]
    public DateTime? RefreshTokenExpiryTime { get; set; }
}