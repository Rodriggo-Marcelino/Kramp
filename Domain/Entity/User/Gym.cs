﻿using Domain.Entity.Enum;
using Domain.Entity.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.User
{
    [Table("gym")]
    public class Gym : UserGeneric
    {

        [StringLength(240)]
        [Column("description", TypeName = "varchar(240)")]
        public string? Description { get; set; }

        //TODO: Owned Types
        public Address? Address { get; set; }

        public void SetTypeDocument()
        {
            TypeDocument = Document.CNPJ;
        }

    }
}
