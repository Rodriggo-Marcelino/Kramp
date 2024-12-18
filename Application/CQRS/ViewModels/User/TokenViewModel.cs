namespace Application.CQRS.ViewModels.User;

public record TokenViewModel : GenericViewModel
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public string? TokenJWT { get; set; }
}