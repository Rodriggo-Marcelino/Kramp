using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Generics
{
    [NotMapped]
    public abstract class EntityGeneric
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("Deleted")]
        [Required(ErrorMessage = "Campo Deletado é obrigatório")]
        public bool Deleted { get; set; } = false;

        protected EntityGeneric()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsDeleted()
        {
            Deleted = true;
            MarkAsUpdated();
        }

        public void MarkAsUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
