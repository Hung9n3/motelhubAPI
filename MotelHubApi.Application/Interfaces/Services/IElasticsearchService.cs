using Nest;

namespace MotelHubApi;
public interface IElasticsearchService
{
    Task<List<TEntity>> SearchByName<TEntity>(QueryContainer[] queries) where TEntity : class, IEntity;
    Task IndexDocument<TEntity>(TEntity document) where TEntity : class, IEntity;
}
