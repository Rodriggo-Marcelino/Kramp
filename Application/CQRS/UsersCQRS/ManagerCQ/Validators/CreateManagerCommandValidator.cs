using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Domain.Entity.User;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Validators
{
    public class CreateManagerCommandValidator : CreateUserCommandValidator<Manager, CreateEntityCommand<Manager, CreateUserDTO, UserViewModel>, CreateUserDTO, UserViewModel>
    {
        public CreateManagerCommandValidator(ValidatorHelper helper) : base(helper)
        {
        }
    }
}
