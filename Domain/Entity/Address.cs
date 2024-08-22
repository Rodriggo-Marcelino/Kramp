using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [NotMapped]
    public class Address
    {
        [Key]
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string? Street { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string? PostalCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string? Number { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? Complement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string? District { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } 

        [Required]
        public string? City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string? State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
