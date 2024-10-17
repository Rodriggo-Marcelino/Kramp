using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update.User;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.User;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update.User
{
    public class UpdateMemberHandler
        (MemberRepository repository, IMapper mapper)
        : UpdateEntityTemplate<
        Member,
        UpdateEntityCommand<Member, UpdateUserDTO, UserViewModel>,
        UpdateUserDTO,
        UserViewModel,
        MemberRepository>(repository, mapper)
    {

        protected override void ManipulateEntityBeforeUpdate(IEnumerable<Member> entities)
        {
            foreach (var entity in entities)
            {
                entity.RefreshToken = Guid.NewGuid().ToString();
                entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
            }
        }
    }
}
