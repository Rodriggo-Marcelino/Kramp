using Domain.Entity.Enum;
using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.User
{
    [Table("member")]
    public class Member : UserGeneric
    {

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Column("surname", TypeName = "varchar(100)")]
        public string? Surname { get; set; }

        [StringLength(240)]
        [Column("user_bio", TypeName = "varchar(240)")]
        public string? UserBio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        public void SetTypeDocument()
        {
            TypeDocument = Document.CPF;
        }
    }
}