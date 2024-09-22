namespace Application.CQRS.GenericsCQRS.User.ViewModel;

public record TokenViewModel
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public string? TokenJWT { get; set; }
}