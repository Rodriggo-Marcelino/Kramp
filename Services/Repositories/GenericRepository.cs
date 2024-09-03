﻿
using Domain.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class GenericRepository<T, Guid> : IRepository<T, Guid> where T : class
    {
        private readonly KrampDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(KrampDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        //GET
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            
            if(entity == null)
            {
                throw new Exception($"Entity of type {typeof(T).Name} with id {Id} not found.");
            }
            
            return entity;
        }

        //TODO: TESTAR MAIS
        public async Task<IEnumerable<T>> FindAllByIdAsync(IEnumerable<Guid> Ids)
        {
            return await _dbSet.Where(e => Ids.Contains
                    (
                    (Guid) e.GetType()
                    .GetProperty("Id")!
                    .GetValue(e,null)!)
                    )
                .ToListAsync();
        }

        //TODO: TESTAR MAIS
        public async Task<IEnumerable<T>> FindAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy)
        {
            return await OrderBy(_dbSet).ToListAsync();
        }

        //TODO: TESTAR MAIS
        public async Task<IEnumerable<T>> FindAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy, int page, int pageSize)
        {
            return await OrderBy(_dbSet)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<bool> ExistsById(Guid Id)
        {
            return await _dbSet.FindAsync(Id) != null;
        }

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        //POST
        public async Task<T> AddAsync(T entity)
        {
            var added = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(added.Entity);
        }

        //PUT
        public async Task<T> UpdateAsync(T entity)
        {
            var updated = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(updated.Entity);
        }

        //DELETE
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            var entity = await GetByIdAsync(Id);
            if (entity != null)
            {
                var deleted = _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAllByIdAsync(IEnumerable<Guid> Ids)
        {
            foreach (var Id in Ids)
            {
                await DeleteByIdAsync(Id);
            }
        }

        public async Task DeleteAllAsync()
        {
            foreach (var entity in _dbSet)
            {
                _dbSet.Remove(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
