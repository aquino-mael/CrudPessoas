﻿using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> InsertAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
    Task<T?> SelectAsync(Guid id);
    Task<IEnumerable<T>?> SelectAsync();
}