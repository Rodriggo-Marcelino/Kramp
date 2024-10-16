using Application.CQRS.Commands;
using Application.CQRS.Templates;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Delete
{
    public class DeleteManagerHandler
        (ManagerRepository repository)
        : DeleteEntityTemplate<
            Manager,
            DeleteEntityCommand<Manager>,
            ManagerRepository>(repository);
}