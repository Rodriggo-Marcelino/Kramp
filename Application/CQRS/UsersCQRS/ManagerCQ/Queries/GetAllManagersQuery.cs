using Application.CQRS.GenericsCQRS.Generic.Queries;
using Application.CQRS.GenericsCQRS.User.ViewModel;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Queries
{
    public record GetAllManagersQuery : GetAllEntitiesQuery<UserGenericViewModel>
    {
    }
}
