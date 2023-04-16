using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Admins { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<SoldFood> SoldFoods { get; set; }
    }
}
