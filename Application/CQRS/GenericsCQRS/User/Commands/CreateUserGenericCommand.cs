using Application.CQRS.GenericsCQRS.User.ViewModel;

namespace Application.CQRS.GenericsCQRS.User.Commands;

public record CreateUserGenericCommand : CreateEntityCommand<UserGenericViewModel>
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? DocumentNumber { get; set; }
};