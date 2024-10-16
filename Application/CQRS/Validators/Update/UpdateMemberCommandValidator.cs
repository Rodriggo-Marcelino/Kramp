using Application.CQRS.DTOs.Update;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.User;

namespace Application.CQRS.Validators.Update
{
    public class UpdateMemberCommandValidator(ValidatorHelper helper)
        : UpdateUserCommandValidator<Member, UpdateUserDTO>(helper);
}
