using Application.GenericsCQRS.User.Validators;
using Application.ManagerCQ.Commands;

namespace Application.ManagerCQ.Validators
{
    public class CreateManagerCommandValidator : CreateUserGenericCommandValidator<CreateManagerCommand>
    {
    }
}
