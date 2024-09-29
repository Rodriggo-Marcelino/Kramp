using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.MemberCQ.Commands;
using Application.CQRS.UsersCQRS.MemberCQ.ViewModels;
using Domain.Entity.User;

namespace Application.CQRS.UsersCQRS.MemberCQ.Validators
{
    public class CreateMemberCommandValidator : CreateUserCommandValidator<Member, CreateMemberCommand, CreateUserDTO, MemberInfoViewModel>
    {
        public CreateMemberCommandValidator(ValidatorHelper helper) : base(helper)
        {
        }
    }
}
