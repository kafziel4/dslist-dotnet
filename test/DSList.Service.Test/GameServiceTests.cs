using DSList.Service.Dtos;
using DSList.Service.Services;
using FluentAssertions;

namespace DSList.Service.Test
{
    public class GameServiceTests
    {
        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnGameMinDtoList()
        {
            // Arrange
            var service = new GameService();
            var expectedFirstGame = new GameMinDto
            {
                Id = 1,
                Title = "Mass Effect Trilogy",
                Year = 2012,
                ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!"
            };

            // Act
            var result = await service.FindAllAsync();

            // Assert
            result.Should().HaveCount(10);
            result.First().Should().BeEquivalentTo(expectedFirstGame, options => options.ComparingByMembers<GameMinDto>());
        }
    }
}
