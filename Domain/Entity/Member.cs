using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Enum;
using Domain.Entity.Interfaces;

namespace Domain.Entity
{
    [Table("member")]
    public class Member : IUser
    {
        [Key]
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Column(TypeName = "varchar(100)")]
        public string? Surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        [StringLength(240)]
        [Column(TypeName = "varchar(240)")]
        public string? UserBio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column(TypeName = "varchar(50)")]
        public string? Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        [Required]
        public string? PasswordHash { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        [Required]
        public Document TypeDocument { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        [Required]
        public string? DocumentNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Timestamp]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? RefreshToken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? RefreshTokenExpiryTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}

//Todo: Remover Exeption