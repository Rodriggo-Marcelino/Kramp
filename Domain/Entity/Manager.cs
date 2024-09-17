using Domain.Entity.Enum;
using Domain.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Generics;

namespace Domain.Entity
{
    [Table("manager")]
    public class Manager : UserGeneric
    {

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

        public List<Permission> Permission { get; set; } = new List<Permission>();
    }
}