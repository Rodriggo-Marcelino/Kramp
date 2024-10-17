using Domain.Entity.User;
using Infrastructure.Persistence;

namespace Services.Repositories
{
    public class GymRepository(KrampDbContext context) : GenericRepository<Gym>(context)
    {
    }
}