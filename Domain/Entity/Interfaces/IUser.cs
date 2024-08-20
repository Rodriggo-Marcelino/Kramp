using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        string? Name { get; set; }
        string? Surname { get; set; }
        string? UserBio { get; set; }
        string? Username { get; set; }
        string? PasswordHash { get; set; }
        DateTime BirthDate { get; set; }

        string? Document { get; set; }

        DateTime CreatedAt { get; set; }
        string? RefreshToken {get; set;}
        string? RefreshTokenExpiryTime {get; set;}

    }
}