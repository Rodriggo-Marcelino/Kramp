using System.Text.Json.Serialization;
using Application.GenericsCQRS.User.Commands;
using Application.MemberCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.MemberCQ.Commands;

public record UpdateMemberCommand : UpdateUserGenericCommand, IRequest<ResponseBase<MemberInfoViewModel>>
{
}