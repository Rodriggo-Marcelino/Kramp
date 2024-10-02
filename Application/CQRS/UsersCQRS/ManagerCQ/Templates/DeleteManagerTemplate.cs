using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Templates
{
    public class DeleteManagerTemplate
        (ManagerRepository repository)
        : DeleteEntityHandler<
            Manager,
            DeleteEntityCommand<Manager>,
            ManagerRepository>(repository);
}