using Domain.Entity.Enum;

namespace Application.ProfessionalCQ.ViewModels
{
    public record ProfessionalInfoViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserBio { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Username { get; set; }
        public Job Job { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

    }
}
