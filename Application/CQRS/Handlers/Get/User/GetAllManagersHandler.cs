using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.User;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get.User
{
    public class GetAllManagersHandler
        (ManagerRepository repository, IMapper mapper)
        : GetAllEntitiesTemplate<
            Manager,
            GetAllEntitiesQuery<UserViewModel>,
            UserViewModel,
            ManagerRepository>(repository, mapper);
}