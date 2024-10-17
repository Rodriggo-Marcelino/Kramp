using Domain.Entity.User;
using Infrastructure.Persistence;

namespace Services.Repositories
{
    public class ManagerRepository(KrampDbContext context) : GenericRepository<Manager>(context)
    {
    }
}