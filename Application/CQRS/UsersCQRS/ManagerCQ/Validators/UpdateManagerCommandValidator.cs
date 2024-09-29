using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Domain.Entity.User;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Validators
{
    public class UpdateManagerCommandValidator : UpdateUserCommandValidator<Manager, UpdateUserCommand<Manager, UserViewModel>, UserViewModel>
    {
        public UpdateManagerCommandValidator(ValidatorHelper helper) : base(helper)
        {
        }
    }
}
