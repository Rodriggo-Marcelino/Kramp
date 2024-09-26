using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.ManagerCQ.ViewModels;
using Domain.Entity.User;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Commands
{
    public record CreateManagerCommand : CreateUserGenericCommand<Manager, ManagerInfoViewModel>
    {
    }
}
