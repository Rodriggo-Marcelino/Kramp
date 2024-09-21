using Domain.Entity.User;
using Infrastructure.Persistence;

namespace Services.Repositories;

public class MemberRepository(KrampDbContext context) : GenericRepository<Member>(context)
{

}