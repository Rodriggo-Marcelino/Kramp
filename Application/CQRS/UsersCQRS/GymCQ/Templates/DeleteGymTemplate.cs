using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.GymCQ.Templates
{
    public class DeleteGymTemplate
        (GymRepository repository)
        : DeleteEntityTemplate<
            Gym,
            DeleteEntityCommand<Gym>,
            GymRepository>(repository);
}
