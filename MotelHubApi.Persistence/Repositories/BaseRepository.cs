using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
{
    protected readonly MotelHubSqlServerDbContext _dbContext;

    public BaseRepository(MotelHubSqlServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<T> Entities => _dbContext.Set<T>();

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        var exist = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new Exception("Not Found");
        _dbContext.Update(entity);
    }

    public virtual Task DeleteAsync(T entity)
    {
        var a = _dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] selectors) 
    {
        IQueryable<T> query = this.Entities;
        if (selectors is not null)
        {
            foreach (var selector in selectors)
            {
                query = query.Include(selector);
            } 
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task DeleteRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
        return Task.CompletedTask;
    }
}

