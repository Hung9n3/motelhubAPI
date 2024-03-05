using Nest;

namespace MotelHubApi;
public interface IElasticsearchService<TEntity> where TEntity : class, IEntity
{
    Task<List<TEntity>> SearchList(QueryContainer[] queries);
    Task IndexDocument(TEntity document);
}
