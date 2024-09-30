using Domain.Entity.Training;
using Infrastructure.Persistence;

namespace Services.Repositories
{
    public class PlanWorkoutRepository(KrampDbContext context) : GenericRepository<PlanWorkout>(context)
    {
    }
}