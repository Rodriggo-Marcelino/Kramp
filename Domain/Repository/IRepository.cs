using Domain.Entity.Generics;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public interface IRepository<T> where T : EntityGeneric
    {
        // GET
        Task<IEnumerable<T?>> GetAllAsync();
        Task<IEnumerable<T?>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        Task<IEnumerable<T?>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int page, int pageSize);
        Task<IEnumerable<T?>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T?>> FindAllByIdAsync(IEnumerable<Guid> ids);
        Task<bool> ExistsById(Guid id);
        Task<int> Count();

        // POST
        Task<T?> AddAsync(T entity);
        Task<IEnumerable<T?>?> AddAsync(IEnumerable<T?> entities);

        // PUT
        Task<T?> UpdateAsync(T entity);
        Task<IEnumerable<T?>?> UpdateAsync(IEnumerable<T?> entities);

        // DELETE
        Task DeleteAsync(T entity);
        Task DeleteAsync(IEnumerable<T?> entities);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAllByIdAsync(IEnumerable<Guid> ids);
    }
}
