using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("gym")]
    public class Gym : UserGeneric
    {

        [StringLength(240)]
        [Column(TypeName = "varchar(240)")]
        public string? Description { get; set; }

        //TODO: Owned Types
        public Address? Address { get; set; }

    }
}
