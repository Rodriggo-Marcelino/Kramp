using Domain.Entity.Enum;
using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.User
{
    [Table("professional")]
    public class Professional : UserGeneric
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

        [Required]
        public Job Job { get; set; }

        public void SetTypeDocument()
        {
            bool isNutricionist =
                Job is Job.NUTRICIONIST;

            bool isProfessorOrTrainer =
                Job is Job.PERSONAL_TRAINER || Job is Job.GYM_PROFESSOR;

            if (isNutricionist)
            {
                TypeDocument = Document.CRN;
            }
            else if (isProfessorOrTrainer)
            {
                TypeDocument = Document.CREF;
            }
            else
            {
                // TODO: Melhorar na fase de tratamento de exceptions
                throw new Exception();
            }
        }
    }
}
