using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.User;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get.User
{
    public class GetManagerByIdhandler
        (ManagerRepository repository, IMapper mapper)
        : GetEntityByIdTemplate<
            Manager,
            GetEntityByIdQuery<UserViewModel>,
            UserViewModel,
            ManagerRepository>(repository, mapper);
}