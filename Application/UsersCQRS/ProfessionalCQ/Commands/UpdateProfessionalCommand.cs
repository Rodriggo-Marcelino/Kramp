using Application.GenericsCQRS.User.Commands;
using Application.ProfessionalCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using MediatR;

namespace Application.ProfessionalCQ.Commands;

public record UpdateProfessionalCommand : UpdateUserGenericCommand, IRequest<ResponseBase<ProfessionalInfoViewModel>>
{
    // Deve-se criar outra requisição para Job e Document Number??
    public Job Job { get; set; }
}