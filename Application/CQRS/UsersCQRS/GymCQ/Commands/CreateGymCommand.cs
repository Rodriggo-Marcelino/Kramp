using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.CQRS.UsersCQRS.GymCQ.Commands
{
    public record CreateGymCommand : CreateUserLoginCommand, IRequest<ResponseBase<GymInfoViewModel>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        // TODO: Address deve fazer parte do Input
        // public Address Address { get; set; }
    }
}
