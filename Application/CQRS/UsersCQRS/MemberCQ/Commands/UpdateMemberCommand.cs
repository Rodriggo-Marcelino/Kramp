using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.MemberCQ.ViewModels;
using Application.Response;
using Domain.Entity.User;
using MediatR;

namespace Application.CQRS.UsersCQRS.MemberCQ.Commands;

public record UpdateMemberCommand : UpdateUserGenericCommand<Member, MemberInfoViewModel>, IRequest<ResponseBase<MemberInfoViewModel>>
{
}