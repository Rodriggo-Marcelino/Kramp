using Domain.Entity.Training;
using Infrastructure.Persistence;

namespace Services.Repositories
{
    public class WorkoutExerciseRepository(KrampDbContext context) : GenericRepository<WorkoutExercise>(context)
    {
    }
}
