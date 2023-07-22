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
        private readonly Mock<IGameService> _mockGameService;
        private readonly Mock<IGameListService> _mockGameListService;
        private readonly GameListController _controller;

        public GameListControllerTests()
        {
            _mockGameService = new Mock<IGameService>();
            _mockGameListService = new Mock<IGameListService>();
            _controller = new GameListController(_mockGameListService.Object, _mockGameService.Object);
        }

        [Fact]
        public async Task FindAll_GetAction_ShouldReturnStatusOkAndListOfGameListDto()
        {
            // Arrange
            var listOfGameList = new List<GameListDto>();
            for (int i = 1; i <= 2; i++)
            {
                listOfGameList.Add(new GameListDto
                {
                    Id = i,
                    Name = "Aventura e RPG"
                });
            }
            _mockGameListService.Setup(_ => _.FindAllAsync()).ReturnsAsync(listOfGameList);

            // Act
            var result = await _controller.FindAll();

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
            _mockGameService.Setup(_ => _.FindByListAsync(1)).ReturnsAsync(gameMinDtoList);

            // Act
            var result = await _controller.FindByList(1);

            // Assert
            var actionResult = result.Should().BeOfType<ActionResult<IEnumerable<GameMinDto>>>().Subject;
            var okObjectResult = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
            var dtos = okObjectResult.Value.Should().BeAssignableTo<IEnumerable<GameMinDto>>().Subject;
            dtos.Should().HaveCount(5);
            dtos.First().Should().BeEquivalentTo(gameMinDtoList[0], options => options.ComparingByMembers<GameMinDto>());
        }

        [Fact]
        public async Task Move_PostAction_ShouldReturnOk()
        {
            // Arrange
            var replacementDto = new ReplacementDto
            {
                SourceIndex = 1,
                DestinationIndex = 3
            };

            // Act
            var result = await _controller.Move(1, replacementDto);

            // Assert
            result.Should().BeAssignableTo<ActionResult>();
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Move_PostAction_ShouldCallGameListServiceMoveAsync()
        {
            // Arrange
            var replacementDto = new ReplacementDto
            {
                SourceIndex = 1,
                DestinationIndex = 3
            };

            // Act
            await _controller.Move(1, replacementDto);

            // Assert
            _mockGameListService.Verify(m => m.MoveAsync(1, 1, 3), Times.Once());
        }
    }
}
