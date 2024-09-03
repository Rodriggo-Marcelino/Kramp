using Domain.Entity.Enum;
using Domain.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("professional")]
    public class Professional : IUser
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

        [Required]
        public Job Job { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public void setTypeDocument()
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
