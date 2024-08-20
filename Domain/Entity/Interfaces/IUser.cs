using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity.Enum;

namespace Domain.Entity.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        string? Name { get; set; }

        string? Username { get; set; }
        string? PasswordHash { get; set; }

        // string? Surname { get; set; } Comentei pois Gym tamb�m � um User
        // string? UserBio { get; set; } Comentei pois Gym tamb�m � um User
        // DateTime BirthDate { get; set; } Comentei pois Gym tamb�m � um User

        Document Document { get; set; }

        DateTime CreatedAt { get; set; }
        string? RefreshToken {get; set;}
        string? RefreshTokenExpiryTime {get; set;}

    }
}