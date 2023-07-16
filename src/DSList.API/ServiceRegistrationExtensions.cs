using DSList.Data.DbContexts;
using DSList.Data.Interfaces;
using DSList.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DSList.API
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection RegisterDataServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                services.AddDbContext<GameDbContext>(options =>
                    options.UseSqlite(configuration.GetConnectionString("GameDBConnectionString")));
            }
            else
            {
                services.AddDbContext<GameDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("GameDBConnectionString")));
            }

            services.AddScoped<IGameRepository, GameReposiotry>();
            return services;
        }
    }
}
