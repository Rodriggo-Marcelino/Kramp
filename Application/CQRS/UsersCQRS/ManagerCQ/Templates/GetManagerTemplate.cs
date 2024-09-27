using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Application.CQRS.UsersCQRS.ManagerCQ.Queries;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Templates
{
    public class GetManagerTemplate : GetEntityTemplate<Manager, GetManagerByIdQuery, UserGenericViewModel, ManagerRepository>
    {
        public GetManagerTemplate(ManagerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
