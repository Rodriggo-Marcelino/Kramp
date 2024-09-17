using Application.GenericsCQRS.User.Commands;
using Application.ProfessionalCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using MediatR;

namespace Application.ProfessionalCQ.Commands
{
    public record CreateProfessionalCommand : CreateUserGenericCommand, IRequest<ResponseBase<ProfessionalInfoViewModel>>
    {
        public Job Job { get; set; }
    }
}
