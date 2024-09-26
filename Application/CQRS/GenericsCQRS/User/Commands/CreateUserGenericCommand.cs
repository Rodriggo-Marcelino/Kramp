using Application.Response;
using MediatR;

namespace Application.CQRS.GenericsCQRS.User.Commands;

public record CreateUserGenericCommand<TEntity, TViewModel> : IRequest<ResponseBase<TViewModel>>
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? DocumentNumber { get; set; }
};