using DSList.API.Controllers;
using DSList.Service.DTOs;
using DSList.Service.Interfaces;
using Moq;

namespace DSList.API.Test
{
    public class GameListControllerTests
    {
        [Fact]
        public async Task FindAll_GetAction_ShouldReturnStatusOkAndListOfGameListDto()
        {
            // Arrange
            var mockService = new Mock<IGameListService>();

            var listOfGameList = new List<GameListDto>();
            for (int i = 1; i <= 2; i++)
            {
                listOfGameList.Add(new GameListDto
                {
                    Id = i,
                    Name = "Aventura e RPG"
                });
            }
            mockService.Setup(_ => _.FindAllAsync()).ReturnsAsync(listOfGameList);

            var controller = new GameListController(mockService.Object);

            // Act

            // Assert
        }
    }
}
