using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.ManagerCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Commands
{
    public record CreateManagerCommand : CreateUserGenericCommand, IRequest<ResponseBase<ManagerInfoViewModel>>
    {
    }
}
