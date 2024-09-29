using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Templates
{
    public class UpdateManagerTemplate : UpdateEntityTemplate<
        Manager,
        UpdateUserCommand<Manager, UserViewModel>,
        UserViewModel,
        ManagerRepository>
    {
        public UpdateManagerTemplate(ManagerRepository repository, IMapper mapper) : base(repository, mapper) { }

        protected override void ManipulateEntityBeforeUpdate(Manager entity)
        {
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
        }
    }
}
