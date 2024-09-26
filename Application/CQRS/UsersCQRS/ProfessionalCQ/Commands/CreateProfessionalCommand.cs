using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using Domain.Entity.User;
using MediatR;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Commands
{
    public record CreateProfessionalCommand : CreateUserGenericCommand<Professional, ProfessionalInfoViewModel>, IRequest<ResponseBase<ProfessionalInfoViewModel>>
    {
        public Job Job { get; set; }
    }
}
