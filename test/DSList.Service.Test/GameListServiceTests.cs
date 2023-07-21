using AutoMapper;
using DSList.Data.Entities;
using DSList.Data.Interfaces;
using DSList.Service.DTOs;
using DSList.Service.Profiles;
using DSList.Service.Services;
using FluentAssertions;
using Moq;

namespace DSList.Service.Test
{
    public class GameListServiceTests
    {
        private readonly Mock<IGameListRepository> _mockRepository;
        private readonly GameListService _service;

        public GameListServiceTests()
        {
            _mockRepository = new Mock<IGameListRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfile<GameListProfile>());
            var mapper = new Mapper(mapperConfiguration);

            _service = new GameListService(_mockRepository.Object, mapper);
        }

        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnListOfGameListDto()
        {
            // Arrange
            var listOfGameList = new List<GameList>();
            for (int i = 1; i <= 2; i++)
            {
                listOfGameList.Add(new GameList
                {
                    Id = i,
                    Name = "Aventura e RPG"
                });
            }
            _mockRepository.Setup(_ => _.FindAllAsync()).ReturnsAsync(listOfGameList);

            var expectedFirstGameList = new GameListDto
            {
                Id = 1,
                Name = "Aventura e RPG"
            };

            // Act          
            var result = await _service.FindAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.First().Should().BeEquivalentTo(expectedFirstGameList, options => options.ComparingByMembers<GameListDto>());
        }

        [Theory]
        [InlineData(1, 3, new long[] { 1, 3, 4, 2, 5 })]
        [InlineData(3, 1, new long[] { 1, 4, 2, 3, 5 })]
        [InlineData(3, 3, new long[] { 1, 2, 3, 4, 5 })]
        public async Task MoveAsync_Invoke_ShouldReplaceGames(
            int sourceIndex, int destinationIndex, long[] expectedGameIds)
        {
            var belongings = GenerateBelongings();
            _mockRepository.Setup(_ => _.SearchBelongingsByListAsync(1)).ReturnsAsync(belongings);

            // Act          
            await _service.MoveAsync(1, sourceIndex, destinationIndex);

            // Assert
            for (int i = 0; i < belongings.Count; i++)
            {
                belongings[i].GameId.Should().Be(expectedGameIds[i]);
            }
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(3, 1)]
        [InlineData(3, 3)]
        public async Task MoveAsync_Invoke_ShouldUpdateBelongingPosition(
            int sourceIndex, int destinationIndex)
        {
            // Arrange
            var belongings = GenerateBelongings();
            _mockRepository.Setup(_ => _.SearchBelongingsByListAsync(1)).ReturnsAsync(belongings);

            // Act          
            await _service.MoveAsync(1, sourceIndex, destinationIndex);

            // Assert
            for (int i = 0; i < belongings.Count; i++)
            {
                belongings[i].Position.Should().Be(i);
            }
        }

        [Fact]
        public async Task MoveAsync_Invoke_ShouldCallSaveChangesAsync()
        {
            // Arrange
            var belongings = GenerateBelongings();
            _mockRepository.Setup(_ => _.SearchBelongingsByListAsync(1)).ReturnsAsync(belongings);

            // Act          
            await _service.MoveAsync(1, 1, 3);

            // Assert
            _mockRepository.Verify(m => m.SaveChangesAsync(), Times.Once());
        }

        private static List<Belonging> GenerateBelongings()
        {
            var belongings = new List<Belonging>();
            for (int i = 1; i <= 5; i++)
            {
                belongings.Add(new Belonging
                {
                    GameId = i,
                    GameListId = 1,
                    Position = i - 1
                });
            }

            return belongings;
        }
    }
}
