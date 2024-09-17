namespace Application.GymCQ.ViewModels;

public record TokenViewModel
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public string? TokenJWT { get; set; }
}