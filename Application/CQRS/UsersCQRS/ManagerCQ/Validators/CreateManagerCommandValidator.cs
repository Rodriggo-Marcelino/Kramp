using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.ManagerCQ.Commands;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Validators
{
    public class CreateManagerCommandValidator : CreateUserGenericCommandValidator<CreateManagerCommand>
    {
    }
}
