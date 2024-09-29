using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Application.Response;
using Domain.Entity.User;
using MediatR;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Commands
{
    public record CreateProfessionalCommand : CreateEntityCommand<Professional, CreateUserDTO, ProfessionalInfoViewModel>, IRequest<ResponseBase<ProfessionalInfoViewModel>>
    {
        public CreateProfessionalCommand(CreateUserDTO data) : base(data)
        {
        }
    }
}
