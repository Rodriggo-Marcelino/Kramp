using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.User
{
    [NotMapped]
    public class Address
    {
        [Required]
        [Column("gym_street")]
        public string? Street { get; set; }
        [Required]
        [Column("gym_postal_code")]
        public string? PostalCode { get; set; }
        [Required]
        [Column("gym_number")]
        public string? Number { get; set; }
        [Column("gym_complement")]
        public string? Complement { get; set; }
        [Required]
        [Column("gym_district")]
        public string? District { get; set; }

        [Required]
        [Column("gym_city")]
        public string? City { get; set; }
        [Required]
        [Column("gym_state")]
        public string? State { get; set; }

    }
}

//Todo: implementar corretamente 