namespace Application.CQRS.GenericsCQRS.User.Commands;

public record CreateUserGenericCommand : CreateUserLoginCommand
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
};