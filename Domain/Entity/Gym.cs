﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity.Interfaces;

namespace Domain.Entity
{
    public class Gym : IUser
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string? Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? PasswordHash { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //CNPJ
        public string? Document { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Address Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? RefreshToken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? RefreshTokenExpiryTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}