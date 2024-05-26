using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi.Infrastructure;
public abstract class BaseLogic<T, Repository> : IBaseLogic<T> where T : IEntity where Repository : IBaseRepository<T>
{
    protected readonly Repository _repository;
    protected readonly RepositoryContext _repositoryContext;
    public BaseLogic(Repository repository, RepositoryContext repositoryContext)
    {
        this._repository = repository;
        this._repositoryContext = repositoryContext;

    }
    public Task DeleteAsync(T entity)
    {
        if (entity == null) return Task.CompletedTask;
        var result = this._repository.DeleteAsync(entity);
        return result;
    }

    public Task<List<T>> GetAllAsync()
    {
        var result = this._repository.GetAllAsync();
        return result;
    }

    public Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] selector)
    {
        var result = this._repository.GetByIdAsync(id, selector);
        return result;
    }

    public Task SaveAsync(T entity)
    {
        if (entity == null) return Task.CompletedTask;
        var result = this._repository.SaveAsync(entity);
        return result;
    }
}
