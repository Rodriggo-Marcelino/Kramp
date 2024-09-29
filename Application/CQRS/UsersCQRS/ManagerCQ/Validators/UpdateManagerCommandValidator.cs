using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Domain.Entity.User;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Validators
{
    public class UpdateManagerCommandValidator(ValidatorHelper helper) : UpdateUserCommandValidator<Manager, UpdateEntityCommand<Manager, UpdateUserDTO, UserViewModel>, UpdateUserDTO, UserViewModel>(helper)
    {
    }
}
