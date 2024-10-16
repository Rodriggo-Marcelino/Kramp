using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get
{
    public class GetAllGymsHandler
        (GymRepository repository, IMapper mapper)
        : GetAllEntitiesTemplate<
            Gym,
            GetAllEntitiesQuery<GymViewModel>,
            GymViewModel,
            GymRepository>(repository, mapper);
}
