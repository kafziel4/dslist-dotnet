using DSList.Data.DbContexts;
using DSList.Data.Entities;
using DSList.Data.Repositories;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DSList.Data.Test
{
    public class GameListRepositoryTests
    {
        private readonly GameDbContext _context;
        private readonly GameListRepository _repository;

        public GameListRepositoryTests()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<GameDbContext>().UseSqlite(connection);
            _context = new GameDbContext(optionsBuilder.Options);
            _context.Database.EnsureCreated();

            _repository = new GameListRepository(_context);
        }

        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnListOfGameList()
        {
            // Arrange
            var expectedGameList = new GameList
            {
                Id = 1,
                Name = "Aventura e RPG"
            };

            // Act
            var result = await _repository.FindAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.First().Should().BeEquivalentTo(expectedGameList, options => options.ComparingByMembers<GameList>());
        }

        [Fact]
        public async Task SearchBelongingsByListAsync_Invoke_ShouldReturnBelongingsList()
        {
            // Arrange
            var expedtedBelonging = new Belonging
            {
                GameId = 1,
                GameListId = 1,
                Position = 0
            };

            // Act
            var result = await _repository.SearchBelongingsByListAsync(1);

            // Assert
            result.Should().HaveCount(5);
            result[0].Should().BeEquivalentTo(expedtedBelonging, options => options.ComparingByMembers<Belonging>());
        }

        [Fact]
        public async Task SearchBelongingsByListAsync_Invoke_ShouldReturnBelongingsOrderedByPosition()
        {
            // Arrange
            var firstItem = await _context.Belongings.FindAsync(1L, 1L);
            firstItem!.Position = 1;
            var secondItem = await _context.Belongings.FindAsync(2L, 1L);
            secondItem!.Position = 0;
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.SearchBelongingsByListAsync(1);

            // Assert
            for (int i = 0; i < result.Count; i++)
            {
                result[i].Position.Should().Be(i);
            }
        }

        [Fact]
        public async Task SaveChangesAsync_Invoke_ShouldSaveChangesToContext()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<GameDbContext>();
            var mockContext = new Mock<GameDbContext>(optionsBuilder.Options);
            var repository = new GameListRepository(mockContext.Object);

            // Act
            await repository.SaveChangesAsync();

            // Assert
            mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }
    }
}
