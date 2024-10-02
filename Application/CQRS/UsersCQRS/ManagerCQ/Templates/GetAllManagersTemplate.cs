using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Templates
{
    public class GetAllManagersTemplate
        (ManagerRepository repository, IMapper mapper)
        : GetAllEntitiesHandler<
            Manager,
            GetAllEntitiesQuery<UserViewModel>,
            UserViewModel,
            ManagerRepository>(repository, mapper);
}