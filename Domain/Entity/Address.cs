using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
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
