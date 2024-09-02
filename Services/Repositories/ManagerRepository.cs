using Domain.Entity;
using Infrastructure.Persistence;

namespace Services.Repositories
{
    public class ManagerRepository(KrampDbContext context) : GenericRepository<Manager>(context)
    {
    }
}
