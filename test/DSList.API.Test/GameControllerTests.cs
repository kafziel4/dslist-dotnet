using DSList.API.Controllers;

namespace DSList.API.Test
{
    public class GameControllerTests
    {
        [Fact]
        public async Task FindAll_GetAction_ShouldReturnStatusOkAndGameMinDtoList()
        {
            // Arrange
            var controller = new GameController();

            // Act
            var result = await controller.FindAll();

            // Assert
        }
    }
}
