using Domain.Entity;
using Infrastructure.Persistence;

namespace Services.Repositories
{
    public class GymRepository(KrampDbContext context) : GenericRepository<Gym>(context)
    {

    }
}