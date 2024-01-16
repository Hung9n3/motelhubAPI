﻿namespace MotelHubApi;

public interface IBaseRepository<T> where T : IEntity
{
    IQueryable<T> Entities { get; }

    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
