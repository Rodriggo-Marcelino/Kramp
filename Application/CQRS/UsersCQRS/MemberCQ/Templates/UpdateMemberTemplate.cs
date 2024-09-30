using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Application.CQRS.GenericsCQRS.User.DTOs;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using AutoMapper;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.MemberCQ.Templates
{
    public class UpdateMemberTemplate
        (MemberRepository repository, IMapper mapper)
        : UpdateEntityHandler<
        Member,
        UpdateEntityCommand<Member, UpdateUserDTO, UserViewModel>,
        UpdateUserDTO,
        UserViewModel,
        MemberRepository>(repository, mapper)
    {

        protected override void ManipulateEntityBeforeUpdate(Member entity)
        {
            entity.RefreshToken = Guid.NewGuid().ToString();
            entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
        }
    }
}
