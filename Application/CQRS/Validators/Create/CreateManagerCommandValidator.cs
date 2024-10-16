using Application.CQRS.DTOs.Create;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.User;

namespace Application.CQRS.Validators.Create
{
    public class CreateManagerCommandValidator(ValidatorHelper helper)
        : CreateUserCommandValidator<Manager, CreateUserDTO>(helper);
}