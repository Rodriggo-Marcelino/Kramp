using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.User;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get.User
{
    public class GetGymByIdHandler
        (GymRepository repository, IMapper mapper)
        : GetEntityByIdTemplate<
            Gym,
            GetEntityByIdQuery<GymViewModel>,
            GymViewModel,
            GymRepository>(repository, mapper);
}
