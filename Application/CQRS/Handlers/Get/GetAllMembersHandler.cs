using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get
{
    public class GetAllMembersHandler
        (MemberRepository repository, IMapper mapper)
        : GetAllEntitiesTemplate<
            Member,
            GetAllEntitiesQuery<UserViewModel>,
            UserViewModel,
            MemberRepository>(repository, mapper);
}
