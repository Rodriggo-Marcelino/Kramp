using Application.CQRS.DTOs.Update.User;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.User;

namespace Application.CQRS.Validators.Update.User
{
    public class UpdateMemberCommandValidator(ValidatorHelper helper)
        : UpdateUserCommandValidator<Member, UpdateUserDTO>(helper);
}
