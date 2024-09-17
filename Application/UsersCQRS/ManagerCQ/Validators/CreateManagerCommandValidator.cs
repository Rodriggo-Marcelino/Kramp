using Application.GenericsCQRS.User.Validators;
using Application.ManagerCQ.Commands;
using FluentValidation;

namespace Application.ManagerCQ.Validators
{
    public class CreateManagerCommandValidator : CreateUserGenericCommandValidator<CreateManagerCommand>
    {
    }
}
