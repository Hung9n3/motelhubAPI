using System.Linq.Expressions;

namespace MotelHubApi;

public interface IBaseRepository<T> where T : IEntity
{
    IQueryable<T> Entities { get; }
    Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] selector);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteRange(IEnumerable<T> entities);
}
