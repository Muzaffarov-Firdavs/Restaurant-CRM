﻿using System.Linq.Expressions;

namespace Restaurant.Data.IRepositories
{
    public interface IRepository<TEntity>
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);
        ValueTask<TEntity> UpdateAsync(TEntity entity);
        ValueTask<bool> DeleteAsync(TEntity entity);
        ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);
        IQueryable<TEntity> SelectAll(
            Expression<Func<TEntity, bool>> expression = null, string[] includes = null, bool isTracking = true);
        ValueTask SaveChangesAsync();
    }
}
