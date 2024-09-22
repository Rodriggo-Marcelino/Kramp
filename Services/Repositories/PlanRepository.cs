using Domain.Entity.Training;
using Infrastructure.Persistence;

namespace Services.Repositories;

public class PlanRepository(KrampDbContext context) : GenericRepository<Plan>(context)
{

}