using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Contexts;
using Restaurant.Data.IRepositories;
using System.Linq.Expressions;

namespace Restaurant.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }


        public async ValueTask<bool> DeleteAsync(TEntity entity)
        {
            this.dbSet.Remove(entity);
            return true;
        }

        public async ValueTask<TEntity> InsertAsync(TEntity entity)
            => (await this.dbSet.AddAsync(entity)).Entity;

        public async ValueTask<TEntity> UpdateAsync(TEntity entity)
           => this.dbContext.Update(entity).Entity;

        public IQueryable<TEntity> SelectAll(
                Expression<Func<TEntity, bool>> expression = null, string[] includes = null, bool isTracking = true)
        {
            IQueryable<TEntity> query = expression is null ? dbSet : dbSet.Where(expression);

            if (includes is null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }

        public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
            => await this.SelectAll(expression, includes).FirstOrDefaultAsync();

        public async ValueTask SaveChangesAsync()
            => await this.dbContext.SaveChangesAsync();
    }
}
