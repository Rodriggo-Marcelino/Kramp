using Application.CQRS.Commands;
using Application.CQRS.Templates;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Delete.User
{
    public class DeleteGymHandler
        (GymRepository repository)
        : DeleteEntityTemplate<
            Gym,
            DeleteEntityCommand<Gym>,
            GymRepository>(repository);
}
