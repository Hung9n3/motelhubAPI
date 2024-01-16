using System;
using System.Collections;

namespace MotelHubApi.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly MotelHubSqlServerDbContext _dbContext;
    private Hashtable _repositories;
    private bool disposed;

    public UnitOfWork(MotelHubSqlServerDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IBaseRepository<T> Repository<T>() where T : class, IEntity
    {
        if (_repositories == null)
            _repositories = new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(IBaseRepository<>);

            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

            _repositories.Add(type, repositoryInstance);
        }

        return (IBaseRepository<T>)_repositories[type];
    }

    public Task Rollback()
    {
        _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        return Task.CompletedTask;
    }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
    {
        throw new NotImplementedException();
    }
}

