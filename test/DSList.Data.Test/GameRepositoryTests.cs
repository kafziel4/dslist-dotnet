﻿using DSList.Data.DbContexts;
using DSList.Data.Entities;
using DSList.Data.Projections;
using DSList.Data.Repositories;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DSList.Data.Test
{
    public class GameRepositoryTests
    {
        private readonly GameRepository _repository;
        private readonly Game _expectedGame;
        private readonly GameDbContext _context;

        public GameRepositoryTests()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<GameDbContext>().UseSqlite(connection);
            _context = new GameDbContext(optionsBuilder.Options);
            _context.Database.EnsureCreated();

            _repository = new GameRepository(_context);

            _expectedGame = new Game
            {
                Id = 1,
                Title = "Mass Effect Trilogy",
                Score = 4.8,
                Year = 2012,
                Genre = "Role-playing (RPG), Shooter",
                Platforms = "XBox, Playstation, PC",
                ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                LongDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus dolorum illum placeat eligendi, quis maiores veniam. " +
                    "Incidunt dolorum, nisi deleniti dicta odit voluptatem nam provident temporibus reprehenderit blanditiis consectetur tenetur. " +
                    "Dignissimos blanditiis quod corporis iste, aliquid perspiciatis architecto quasi tempore ipsam voluptates ea ad distinctio, sapiente qui, amet quidem culpa."
            };
        }

        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnGameList()
        {
            // Act
            var result = await _repository.FindAllAsync();

            // Assert
            result.Should().HaveCount(10);
            result.First().Should().BeEquivalentTo(_expectedGame, options => options.ComparingByMembers<Game>());
        }

        [Fact]
        public async Task FindByIdAsync_Invoke_ShouldReturnGame()
        {
            // Act
            var result = await _repository.FindByIdAsync(1);

            // Assert
            result.Should().BeEquivalentTo(_expectedGame, options => options.ComparingByMembers<Game>());
        }

        [Fact]
        public async Task SearchByListAsync_Invoke_ShouldReturnGameMinProjectionList()
        {
            // Arrange
            var expectedGame = new GameMinProjection
            {
                Id = 1,
                Title = "Mass Effect Trilogy",
                Year = 2012,
                ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                Position = 0
            };

            // Act
            var result = await _repository.SearchByListAsync(1);

            // Assert
            result.Should().HaveCount(5);
            result.First().Should().BeEquivalentTo(expectedGame, options => options.ComparingByMembers<GameMinProjection>());
        }

        [Fact]
        public async Task SearchByListAsync_Invoke_ShouldReturnGamesOrderedByPosition()
        {
            // Arrange
            var gameList = await _context.Belongings
                .Where(b => b.GameListId == 1)
                .ToListAsync();

            gameList[0].Position = 1;
            gameList[1].Position = 0;
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.SearchByListAsync(1);

            // Assert
            var listResult = result.ToList();
            for (int i = 0; i < listResult.Count; i++)
            {
                listResult[i].Position.Should().Be(i);
            }
        }
    }
}
