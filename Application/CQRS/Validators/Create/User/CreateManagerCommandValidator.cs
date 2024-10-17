using Application.CQRS.DTOs.Create.User;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.User;

namespace Application.CQRS.Validators.Create.User
{
    public class CreateManagerCommandValidator(ValidatorHelper helper)
        : CreateUserCommandValidator<Manager, CreateUserDTO>(helper);
}