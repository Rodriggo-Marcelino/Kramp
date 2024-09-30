using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.GymCQ.Templates
{
    public class GetGymByIdTemplate(GymRepository repository, IMapper mapper)
        : GetEntityByIdTemplate<
            Gym,
            GetEntityByIdQuery<GymViewModel>,
            GymViewModel,
            GymRepository>(repository, mapper);
}
