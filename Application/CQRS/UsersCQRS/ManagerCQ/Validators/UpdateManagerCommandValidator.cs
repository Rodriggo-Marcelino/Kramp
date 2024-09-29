using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Domain.Entity.User;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Validators
{
    public class UpdateManagerCommandValidator : UpdateUserGenericCommandValidator<Manager, UpdateUserGenericCommand<Manager, UserGenericViewModel>, UserGenericViewModel>
    {
        public UpdateManagerCommandValidator(ValidatorHelper helper) : base(helper)
        {
        }
    }
}
