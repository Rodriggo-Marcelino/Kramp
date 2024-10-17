using Domain.Entity.Training;
using Infrastructure.Persistence;

namespace Services.Repositories;

public class WorkoutRepository(KrampDbContext context) : GenericRepository<Workout>(context)
{
}