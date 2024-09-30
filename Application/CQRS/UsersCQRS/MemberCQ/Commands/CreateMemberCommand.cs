using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.MemberCQ.ViewModels;
using Application.Response;
using Domain.Entity.User;
using MediatR;

namespace Application.CQRS.UsersCQRS.MemberCQ.Commands
{
    public record CreateMemberCommand : CreateEntityCommand<Member, CreateUserDTO, MemberInfoViewModel>,
        IRequest<ResponseBase<MemberInfoViewModel>>
    {
        public CreateMemberCommand(CreateUserDTO data) : base(data)
        {
        }
    }
}