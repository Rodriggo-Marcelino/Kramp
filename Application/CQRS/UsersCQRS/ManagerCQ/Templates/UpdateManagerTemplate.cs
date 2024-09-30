using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Templates
{
    public class UpdateManagerTemplate(ManagerRepository repository, IMapper mapper)
        : UpdateEntityTemplate<
        Manager,
        UpdateEntityCommand<Manager, UpdateUserDTO, UserViewModel>,
        UpdateUserDTO,
        UserViewModel,
        ManagerRepository>(repository, mapper)
    {
        protected override void ManipulateEntityBeforeUpdate(Manager entity)
        {
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
        }
    }
}