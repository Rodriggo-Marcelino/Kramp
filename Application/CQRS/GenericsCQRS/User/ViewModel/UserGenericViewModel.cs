namespace Application.CQRS.GenericsCQRS.User.ViewModel;

public record UserGenericViewModel : TokenViewModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Username { get; set; }
}