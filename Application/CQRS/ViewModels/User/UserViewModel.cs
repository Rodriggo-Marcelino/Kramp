namespace Application.CQRS.ViewModels.User;

public record UserViewModel : TokenViewModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Username { get; set; }
    public int Points { get; set; }
}