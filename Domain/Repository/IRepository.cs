
namespace Domain.Repository
{
    public interface IRepository<T, Guid> where T : class
    {
        //GET
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid Id);
        Task<IEnumerable<T>> FindAllByIdAsync(IEnumerable<Guid> Ids);
        Task<IEnumerable<T>> FindAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy);
        Task<IEnumerable<T>> FindAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy, int page, int pageSize);
        Task<bool> ExistsById(Guid Id);
        Task<int> Count();
        
        //POST
        Task<T> AddAsync(T entity);
        
        //PUT
        Task<T> UpdateAsync(T entity);
        
        //DELETE
        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(Guid Id);
        Task DeleteAllByIdAsync(IEnumerable<Guid> Ids);
        Task DeleteAllAsync();
        Task DeleteAllAsync(IEnumerable<T> entities);

    }
}
