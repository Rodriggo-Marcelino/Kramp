using Application.CQRS.GenericsCQRS.Generic.Commands;
using Domain.Entity.Generics;

namespace Application.CQRS.GenericsCQRS.User.Commands;

public record UpdateUserCommand<TEntity, TViewModel> : UpdateEntityCommandBase<TEntity, TViewModel>
    where TEntity : UserGeneric
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Username { get; set; }
    public string? DocumentNumber { get; set; }
};