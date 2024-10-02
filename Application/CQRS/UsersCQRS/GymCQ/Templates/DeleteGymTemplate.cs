using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.GymCQ.Templates
{
    public class DeleteGymTemplate
        (GymRepository repository)
        : DeleteEntityHandler<
            Gym,
            DeleteEntityCommand<Gym>,
            GymRepository>(repository);
}
