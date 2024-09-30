using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.DTOs;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Application.Response;
using Domain.Entity.User;
using MediatR;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Commands;

public record UpdateProfessionalCommand :
    UpdateEntityCommand<Professional, UpdateProfessionalDTO, ProfessionalInfoViewModel>,
    IRequest<ResponseBase<ProfessionalInfoViewModel>>
{
    public UpdateProfessionalCommand(Guid id, UpdateProfessionalDTO data) : base(id, data)
    {
    }
}