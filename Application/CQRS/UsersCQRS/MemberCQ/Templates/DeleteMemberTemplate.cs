using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Templates;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.MemberCQ.Templates
{
    public class DeleteMemberTemplate
        (MemberRepository repository)
        : DeleteEntityTemplate<
            Member,
            DeleteEntityCommand<Member>,
            MemberRepository>(repository);
}
