using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Application.Response;
using Domain.Entity.User;
using MediatR;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Commands;

public record UpdateProfessionalCommand : UpdateUserCommand<Professional, ProfessionalInfoViewModel>, IRequest<ResponseBase<ProfessionalInfoViewModel>>
{
    public UpdateProfessionalCommand(Guid id) : base(id)
    {
    }
}