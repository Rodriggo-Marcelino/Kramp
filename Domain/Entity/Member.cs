using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity.Interfaces;

namespace Domain.Entity
{
    public class Member : IUser
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? Surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? UserBio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime BirthDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string? Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? PasswordHash { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //CPF
        public string? Document { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? RefreshToken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? RefreshTokenExpiryTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}