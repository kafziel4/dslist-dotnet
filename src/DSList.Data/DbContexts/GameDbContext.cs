using DSList.Data.Configuration;
using DSList.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSList.Data.DbContexts
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
