namespace Application.GenericsCQRS.User.Commands;

public record CreateUserLoginCommand
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? DocumentNumber { get; set; }
}