using DSList.Data.DbContexts;
using DSList.Data.Interfaces;
using DSList.Data.Repositories;
using DSList.Service.Interfaces;
using DSList.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace DSList.API
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection RegisterAppServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                services.AddDbContext<GameDbContext>(options =>
                    options.UseSqlite(configuration.GetConnectionString("GameDBConnectionString"),
                        optionsBuilder => optionsBuilder.MigrationsAssembly("SqliteMigrations")));
            }
            else
            {
                services.AddDbContext<GameDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("GameDBConnectionString"),
                        optionsBuilder => optionsBuilder.MigrationsAssembly("PostgresMigrations")));
            }

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameListRepository, GameListRepository>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameListService, GameListService>();
            return services;
        }
    }
}
