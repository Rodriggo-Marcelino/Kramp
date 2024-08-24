using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [NotMapped]
    public class Address
    {
        [Required]
        public string? Street { get; set; }
        [Required]
        public string? PostalCode { get; set; }
        [Required]
        public string? Number { get; set; }
        public string? Complement { get; set; }
        [Required]
        public string? District { get; set; }

        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }

    }
}
