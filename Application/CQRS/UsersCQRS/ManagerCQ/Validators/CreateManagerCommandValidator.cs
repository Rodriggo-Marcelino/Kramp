using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Domain.Entity.User;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Validators
{
    public class CreateManagerCommandValidator : CreateUserCommandValidator<Manager, CreateUserCommand<Manager, UserGenericViewModel>, UserGenericViewModel>
    {
        public CreateManagerCommandValidator(ValidatorHelper helper) : base(helper)
        {
        }
    }
}
