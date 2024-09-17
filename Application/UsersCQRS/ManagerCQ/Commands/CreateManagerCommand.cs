using Application.GenericsCQRS.User.Commands;
using Application.ManagerCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.ManagerCQ.Commands
{
    public record CreateManagerCommand : CreateUserGenericCommand, IRequest<ResponseBase<ManagerInfoViewModel>>
    {
    }
}
