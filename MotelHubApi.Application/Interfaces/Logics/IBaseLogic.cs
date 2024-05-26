using System.Linq.Expressions;

namespace MotelHubApi;

public interface IBaseLogic<T> where T : IEntity
{
    Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] selector);
    Task<List<T>> GetAllAsync();
    Task DeleteAsync(T entity);
    Task SaveAsync (T entity);
}
