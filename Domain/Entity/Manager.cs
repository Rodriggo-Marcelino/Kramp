using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Enum;

namespace Domain.Entity
{
    [Table("manager")]
    public class Manager
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
        public string? Surname { get; set; }

        [StringLength(240)]
        [Column(TypeName = "varchar(240)")]
        public string? UserBio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

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

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public List<Permission> Permission { get; set; } = new List<Permission>();
    }
}


//Todo: Refazer usando a interface 