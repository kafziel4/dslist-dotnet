using DSList.API.Controllers;
using DSList.Service.Dtos;
using DSList.Service.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace DSList.API.Test
{
    public class GameControllerTests
    {
        private readonly IGameService _mockService;
        private readonly GameController _controller;

        public GameControllerTests()
        {
            _mockService = Substitute.For<IGameService>();
            _controller = new GameController(_mockService);
        }

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

            _mockService.FindAllAsync().Returns(gameList);

            // Act
            var result = await _controller.FindAll();

            // Assert
            var actionResult = result.Should().BeOfType<ActionResult<IEnumerable<GameMinDto>>>().Subject;
            var okObjectResult = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
            var dtos = okObjectResult.Value.Should().BeAssignableTo<IEnumerable<GameMinDto>>().Subject;
            dtos.Should().HaveCount(10);
            dtos.First().Should().BeEquivalentTo(gameList[0], options => options.ComparingByMembers<GameMinDto>());
        }

        [Fact]
        public async Task FindById_GetAction_ShouldReturnStatusOkAndGameDto()
        {
            // Arrange
            var game = new GameDto
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

            _mockService.FindByIdAsync(1).Returns(game);

            // Act
            var result = await _controller.FindById(1);

            // Assert
            var actionResult = result.Should().BeOfType<ActionResult<GameDto>>().Subject;
            var okObjectResult = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
            var dto = okObjectResult.Value.Should().BeAssignableTo<GameDto>().Subject;
            dto.Should().BeEquivalentTo(game, options => options.ComparingByMembers<GameMinDto>());
        }
    }
}
