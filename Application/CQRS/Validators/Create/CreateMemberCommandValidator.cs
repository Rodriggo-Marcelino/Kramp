using Application.CQRS.DTOs.Create;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.User;

namespace Application.CQRS.Validators.Create
{
    public class CreateMemberCommandValidator(ValidatorHelper helper)
        : CreateUserCommandValidator<Member, CreateUserDTO>(helper);
}
