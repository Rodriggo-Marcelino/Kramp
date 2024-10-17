using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update.User;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.User;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update.User
{
    public class UpdateProfessionalHandler(ProfessionalRepository repository, IMapper mapper)
        : UpdateEntityTemplate<
            Professional,
            UpdateEntityCommand<Professional, UpdateProfessionalDTO, ProfessionalViewModel>,
            UpdateProfessionalDTO,
            ProfessionalViewModel,
            ProfessionalRepository>(repository, mapper)
    {
        protected override void ManipulateEntityBeforeUpdate(IEnumerable<Professional> entities)
        {
            foreach (var entity in entities)
            {
                entity.RefreshToken = Guid.NewGuid().ToString();
                entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
                entity.SetTypeDocument();
            }
        }
    }
}
