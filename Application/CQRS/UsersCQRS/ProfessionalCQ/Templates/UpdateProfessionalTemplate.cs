using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.UsersCQRS.ProfessionalCQ.DTOs;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Templates
{
    public class UpdateProfessionalTemplate(ProfessionalRepository repository, IMapper mapper)
        : UpdateEntityHandler<
            Professional,
            UpdateEntityCommand<Professional, UpdateProfessionalDTO, ProfessionalViewModel>,
            UpdateProfessionalDTO,
            ProfessionalViewModel,
            ProfessionalRepository>(repository, mapper)
    {
        protected override void ManipulateEntityBeforeUpdate(Professional entity)
        {
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            entity.SetTypeDocument();
        }
    }
}
