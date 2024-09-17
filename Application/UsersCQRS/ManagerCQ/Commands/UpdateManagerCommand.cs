using Application.ManagerCQ.ViewModels;
using Application.Response;
using MediatR;
using System.Text.Json.Serialization;
using Application.GenericsCQRS.User.Commands;

namespace Application.ManagerCQ.Commands
{
    public record UpdateManagerCommand : UpdateUserGenericCommand, IRequest<ResponseBase<ManagerInfoViewModel>>
    {
    }
}
