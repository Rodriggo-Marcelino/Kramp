﻿using Application.CQRS.GenericsCQRS.Generic.ViewModel;

namespace Application.CQRS.UsersCQRS.ManagerCQ.ViewModels
{
    public record ManagerInfoViewModel : GenericViewModel
    {
        public string? Surname { get; set; }
        public string? UserBio { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Username { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? TokenJWT { get; set; }
    }
}
