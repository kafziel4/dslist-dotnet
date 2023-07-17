using DSList.API.Controllers;
using DSList.Service.Dtos;
using DSList.Service.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DSList.API.Test
{
    public class GameControllerTests
    {
        [Fact]
        public async Task FindAll_GetAction_ShouldReturnStatusOkAndGameMinDtoList()
        {
            // Arrange
            var gameList = new List<GameMinDto>();
            for (int i = 1; i <= 10; i++)
            {
                gameList.Add(new GameMinDto
                {
                    Id = i,
                    Title = "Mass Effect Trilogy",
                    Year = 2012,
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                    ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!"
                });
            }
            var gameServiceMock = new Mock<IGameService>();
            gameServiceMock.Setup(_ => _.FindAllAsync()).ReturnsAsync(gameList);

            var controller = new GameController(gameServiceMock.Object);
            var expectedFirstGame = new GameMinDto
            {
                Id = 1,
                Title = "Mass Effect Trilogy",
                Year = 2012,
                ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!"
            };

            // Act
            var result = await controller.FindAll();

            // Assert
            var actionResult = result.Should().BeOfType<ActionResult<IEnumerable<GameMinDto>>>().Subject;
            var okObjectResult = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
            var dtos = okObjectResult.Value.Should().BeAssignableTo<IEnumerable<GameMinDto>>().Subject;
            dtos.Should().HaveCount(10);
            dtos.First().Should().BeEquivalentTo(expectedFirstGame, options => options.ComparingByMembers<GameMinDto>());
        }
    }
}
