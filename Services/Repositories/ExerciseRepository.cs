using Domain.Entity;
using Infrastructure.Persistence;

namespace Services.Repositories;

public class ExerciseRepository(KrampDbContext context) : GenericRepository<Exercise>(context)
{

}