using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using Domain.Entity.User;
using MediatR;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Commands;

public record UpdateProfessionalCommand : UpdateUserGenericCommand<Professional, ProfessionalInfoViewModel>, IRequest<ResponseBase<ProfessionalInfoViewModel>>
{
    // Deve-se criar outra requisição para Job e Document Number??
    public Job Job { get; set; }
}