using Application.CQRS.Queries;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.User;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Get.User
{
    public class GetMemberByIdHandler(MemberRepository repository, IMapper mapper)
    : GetEntityByIdTemplate<
        Member,
        GetEntityByIdQuery<UserViewModel>,
        UserViewModel,
        MemberRepository>(repository, mapper);
}
