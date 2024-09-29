using Application.CQRS.GenericsCQRS.User.Validators;
using Application.CQRS.UsersCQRS.MemberCQ.Commands;
using Application.CQRS.UsersCQRS.MemberCQ.ViewModels;
using Domain.Entity.User;

namespace Application.CQRS.UsersCQRS.MemberCQ.Validators
{
    public class CreateMemberCommandValidator : CreateUserGenericCommandValidator<Member, CreateMemberCommand, MemberInfoViewModel>
    {
        public CreateMemberCommandValidator(ValidatorHelper helper) : base(helper)
        {
        }
    }
}
