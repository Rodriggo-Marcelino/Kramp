using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update.User;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.User;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update.User
{
    public class UpdateManagerHandler
        (ManagerRepository repository, IMapper mapper)
        : UpdateEntityTemplate<
                Manager,
                UpdateEntityCommand<Manager, UpdateUserDTO, UserViewModel>,
                UpdateUserDTO,
                UserViewModel,
                ManagerRepository>(repository, mapper)
    {
        protected override void ManipulateEntityBeforeUpdate(IEnumerable<Manager> entities)
        {
            foreach (var entity in entities)
            {
                entity.RefreshToken = Guid.NewGuid().ToString();
                entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            }
        }
    }
}