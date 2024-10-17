using Domain.Entity.Enum;
using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.User
{
    [Table("manager")]
    public class Manager : UserGeneric
    {

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column("surname", TypeName = "varchar(50)")]
        public string? Surname { get; set; }

        [StringLength(240)]
        [Column("user_bio", TypeName = "varchar(240)")]
        public string? UserBio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        public List<Permission> Permission { get; set; } = new List<Permission>();

        public void SetTypeDocument()
        {
            TypeDocument = Document.CPF;
        }
    }
}