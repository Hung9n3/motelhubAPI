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

    public virtual Task UpdateAsync(T entity)
    {
        var exist = _dbContext.Set<T>().Find(entity.Id) ?? throw new Exception("Not Found");
        _dbContext.Entry(exist).CurrentValues.SetValues(entity);
        return Task.CompletedTask;
    }

    public virtual Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id, IEnumerable<Expression<Func<T, IEntity[]>>>? selectors = null) 
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
}

