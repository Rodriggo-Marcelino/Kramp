using Domain.Entity.Generics;
using Domain.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : EntityGeneric
    {
        private readonly KrampDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(KrampDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        #region Repository READ
        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _dbSet.Where(entity => !entity.Deleted).ToListAsync();
        }

        public async Task<IEnumerable<T?>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return await orderBy(_dbSet)
                .Where(entity => !entity.Deleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<T?>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int page, int pageSize)
        {
            return await orderBy(_dbSet)
                .Where(entity => !entity.Deleted)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<T?>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet
                .Where(predicate)
                .Where(entity => !entity.Deleted)
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null || entity.Deleted)
            {
                throw new Exception($"Entity of type {typeof(T).Name} with id {id} not found.");
            }

            return entity;
        }

        public async Task<IEnumerable<T?>> FindAllByIdAsync(IEnumerable<Guid> ids)
        {
            return await _dbSet
                .Where(entity => ids.Contains(entity.Id) && !entity.Deleted)
                .ToListAsync();
        }

        public async Task<bool> ExistsById(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null && !entity.Deleted;
        }

        public async Task<int> Count()
        {
            return await _dbSet.Where(entity => !entity.Deleted).CountAsync();
        }
        #endregion

        #region Repository CREATE
        public async Task<T?> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T?>?> AddAsync(IEnumerable<T?> entities)
        {
            if (entities != null && entities.Any())
            {
                await _dbSet.AddRangeAsync(entities);
                await _context.SaveChangesAsync();
                return entities;
            }
            return null;
        }
        #endregion

        #region Repository UPDATE
        public async Task<T?> UpdateAsync(T entity)
        {
            entity.MarkAsUpdated();
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T?>?> UpdateAsync(IEnumerable<T?> entities)
        {
            if (entities != null && entities.Any())
            {
                foreach (var entity in entities)
                {
                    entity.MarkAsUpdated();
                }
                _dbSet.UpdateRange(entities);
                await _context.SaveChangesAsync();
                return entities;
            }
            return null;
        }
        #endregion

        #region Repository DELETE (Logic)
        public async Task DeleteAsync(T entity)
        {
            entity.MarkAsDeleted();
            await UpdateAsync(entity);
        }

        public async Task DeleteAsync(IEnumerable<T?> entities)
        {
            foreach (var entity in entities)
            {
                entity?.MarkAsDeleted();
            }
            await UpdateAsync(entities);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                await DeleteAsync(entity);
            }
        }

        public async Task DeleteAllByIdAsync(IEnumerable<Guid> ids)
        {
            var entities = await FindAllByIdAsync(ids);
            await DeleteAsync(entities);
        }
        #endregion
    }
}
