using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.MemberCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.CQRS.UsersCQRS.MemberCQ.Commands
{
    public record CreateMemberCommand : CreateUserGenericCommand, IRequest<ResponseBase<MemberInfoViewModel>>
    {
    }
}
