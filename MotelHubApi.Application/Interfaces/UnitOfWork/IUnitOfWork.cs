using System;
namespace MotelHubApi;

public interface IUnitOfWork
{
    IBaseRepository<T> Repository<T>() where T : BaseEntity;
    Task<int> Save(CancellationToken cancellationToken);
    Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
    Task Rollback();
}

