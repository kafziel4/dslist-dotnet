using DSList.Data.DbContexts;
using DSList.Data.Entities;
using DSList.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DSList.Data.Test
{
    public class GameListRepositoryTests
    {
        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnListOfGameList()
        {
            // Arrange
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<GameDbContext>().UseSqlite(connection);
            var context = new GameDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var repository = new GameListRepository(context);

            var expectedGameList = new GameList
            {
                Id = 1,
                Name = "Aventura e RPG"
            };

            // Act

            // Assert
        }
    }
}
