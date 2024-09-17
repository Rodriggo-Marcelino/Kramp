using Application.GymCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.GymCQ.Commands
{
    public record CreateGymCommand : IRequest<ResponseBase<GymInfoViewModel>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? DocumentNumber { get; set; }

        // TODO: Address deve fazer parte do Input
        // public Address Address { get; set; }
    }
}
