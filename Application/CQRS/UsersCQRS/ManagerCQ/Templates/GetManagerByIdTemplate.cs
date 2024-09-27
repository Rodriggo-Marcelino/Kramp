using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Application.CQRS.UsersCQRS.ManagerCQ.Queries;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Templates
{
    public class GetManagerByIdTemplate : GetEntityByIdTemplate<Manager, GetManagerByIdQuery, UserGenericViewModel, ManagerRepository>
    {
        public GetManagerByIdTemplate(ManagerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
