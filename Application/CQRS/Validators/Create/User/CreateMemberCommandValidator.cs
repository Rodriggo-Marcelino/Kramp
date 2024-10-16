using Application.CQRS.DTOs.Create.User;
using Application.CQRS.GenericsCQRS.Generic.Validator;
using Domain.Entity.User;

namespace Application.CQRS.Validators.Create.User
{
    public class CreateMemberCommandValidator(ValidatorHelper helper)
        : CreateUserCommandValidator<Member, CreateUserDTO>(helper);
}
