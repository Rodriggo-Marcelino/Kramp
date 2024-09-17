using Application.GenericsCQRS.User.Commands;
using Application.MemberCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.MemberCQ.Commands
{
    public record CreateMemberCommand : CreateUserGenericCommand, IRequest<ResponseBase<MemberInfoViewModel>>
    {
    }
}
