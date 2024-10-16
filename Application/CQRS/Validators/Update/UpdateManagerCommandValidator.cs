using Application.CQRS.DTOs.Update;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.User;

namespace Application.CQRS.Validators.Update
{
    public class UpdateManagerCommandValidator(ValidatorHelper helper)
        : UpdateUserCommandValidator<Manager, UpdateUserDTO>(helper);
}