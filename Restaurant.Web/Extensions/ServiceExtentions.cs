using Restaurant.Data.IRepositories;
using Restaurant.Data.Repositories;
using Restaurant.Service.Interfaces;
using Restaurant.Service.Services;

namespace Restaurant.Web.Extensions
{
    public static class ServiceExtentions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISoldFoodService, SoldFoodService>();
            services.AddScoped<IFoodService, FoodService>();

            // repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
