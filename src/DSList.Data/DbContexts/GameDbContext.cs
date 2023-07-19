using DSList.Data.Configuration;
using DSList.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSList.Data.DbContexts
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameList> GameLists { get; set; }
        public DbSet<Belonging> Belongings { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GameListConfiguration());
            modelBuilder.ApplyConfiguration(new BelongingConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
