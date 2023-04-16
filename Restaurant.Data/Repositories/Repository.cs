using Restaurant.Data.IRepositories;
using Restaurant.Domain.Commons;
using System.Linq.Expressions;

namespace Restaurant.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public ValueTask<bool> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null, bool isTracking = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
