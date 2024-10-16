using Application.CQRS.Commands.Delete;
using Application.CQRS.Templates;
using Domain.Entity.User;
using Services.Repositories;

namespace Application.CQRS.Handlers.Delete
{
    public class DeleteMemberHandler
        (MemberRepository repository)
        : DeleteEntityTemplate<
            Member,
            DeleteEntityCommand<Member>,
            MemberRepository>(repository);
}
