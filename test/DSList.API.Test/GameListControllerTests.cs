using DSList.API.Controllers;
using DSList.Service.Dtos;
using DSList.Service.DTOs;
using DSList.Service.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DSList.API.Test
{
    public class GameListControllerTests
    {
        [Fact]
        public async Task FindAll_GetAction_ShouldReturnStatusOkAndListOfGameListDto()
        {
            // Arrange
            var mockGameService = new Mock<IGameService>();
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

            var controller = new GameListController(mockService.Object, mockGameService.Object);

            // Act
            var result = await controller.FindAll();

            // Assert
            var actionResult = result.Should().BeOfType<ActionResult<IEnumerable<GameListDto>>>().Subject;
            var okObjectResult = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
            var dtos = okObjectResult.Value.Should().BeAssignableTo<IEnumerable<GameListDto>>().Subject;
            dtos.Should().HaveCount(2);
            dtos.First().Should().BeEquivalentTo(listOfGameList[0], options => options.ComparingByMembers<GameListDto>());
        }

        [Fact]
        public async Task FindByList_GetAction_ShouldReturnStatusOkAndGameMinDtoList()
        {
            // Arrange
            var mockGameService = new Mock<IGameService>();
            var mockGameListService = new Mock<IGameListService>();

            var gameMinDtoList = new List<GameMinDto>();
            for (int i = 1; i <= 5; i++)
            {
                gameMinDtoList.Add(new GameMinDto
                {
                    Id = i,
                    Title = "Mass Effect Trilogy",
                    Year = 2012,
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                    ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!"
                });
            }
            mockGameService.Setup(_ => _.FindByListAsync(1)).ReturnsAsync(gameMinDtoList);

            var controller = new GameListController(mockGameListService.Object, mockGameService.Object);

            // Act

            // Assert
        }
    }
}
