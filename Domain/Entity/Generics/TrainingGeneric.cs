using Domain.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Generics
{
    [NotMapped]
    public abstract class TrainingGeneric : EntityGeneric, ITraining
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column("name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [StringLength(240)]
        [Column("description", TypeName = "varchar(240)")]
        public string? Description { get; set; }
    }
}
