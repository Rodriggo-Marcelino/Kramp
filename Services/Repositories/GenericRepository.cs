
using Domain.Repository;
using Infrastructure.Persistence;

namespace Services.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly KrampDbContext _context;

        public GenericRepository(KrampDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var added = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(added.Entity);
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            var deleted = _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(deleted.Entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = _context.Set<T>().AsEnumerable();
            return await Task.FromResult(entities);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new Exception($"Entity of type {typeof(T).Name} with id {id} not found.");
            }

            return await Task.FromResult(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var updated = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(updated.Entity);
        }
    }
}
