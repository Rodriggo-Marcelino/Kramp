using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.MemberCQ.ViewModels;
using Application.Response;
using Domain.Entity.User;
using MediatR;

namespace Application.CQRS.UsersCQRS.MemberCQ.Commands;

public record UpdateMemberCommand : UpdateEntityCommand<Member, UpdateUserDTO, MemberInfoViewModel>, IRequest<ResponseBase<MemberInfoViewModel>>
{
    public UpdateMemberCommand(Guid id, UpdateUserDTO data) : base(id, data)
    {
    }
}