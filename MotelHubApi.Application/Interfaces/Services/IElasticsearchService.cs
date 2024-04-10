namespace MotelHubApi;
public interface IElasticsearchService
{
    Task<List<TEntity>> Search<TEntity>(SearchOptions searchQuery) where TEntity : class, IEntity;
    Task IndexDocument<TEntity>(TEntity document) where TEntity : class, IEntity;
}
