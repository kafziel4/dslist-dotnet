using DSList.Data.Entities;
using DSList.Data.Interfaces;
using Moq;

namespace DSList.Service.Test
{
    public class GameListServiceTests
    {
        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnListOfGameListDto()
        {
            // Arrange
            var mockRepository = new Mock<IGameListRepository>();

            var listOfGameList = new List<GameList>();
            for (int i = 1; i <= 2; i++)
            {
                listOfGameList.Add(new GameList
                {
                    Id = i,
                    Name = "Aventura e RPG"
                });
            }
            mockRepository.Setup(_ => _.FindAllAsync()).ReturnsAsync(listOfGameList);

            var service = new GameListService(mockRepository.Object);

            // Act          

            // Assert
        }
    }
}
