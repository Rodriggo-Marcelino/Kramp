using Domain.Entity.User;
using Infrastructure.Persistence;

namespace Services.Repositories;

public class ProfessionalRepository(KrampDbContext context) : GenericRepository<Professional>(context)
{
}