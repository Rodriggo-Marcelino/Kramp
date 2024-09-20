
namespace Domain.Repository
{
    public interface IRepository<T> where T : class
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
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        //PUT
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

        //DELETE
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        Task DeleteByIdAsync(Guid Id, CancellationToken cancellationToken);
        Task DeleteAllByIdAsync(IEnumerable<Guid> Ids, CancellationToken cancellationToken);
        Task DeleteAllAsync(CancellationToken cancellationToken);
        Task DeleteAllAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    }
}
