using DSList.Data.Entities;
using DSList.Data.Repositories;
using FluentAssertions;

namespace DSList.Data.Test
{
    public class GameRepositoryTests
    {
        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnGameList()
        {
            // Arrange
            var repository = new GameReposiotry();

            var expectedGame = new Game
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

            // Act
            var result = await repository.FindAllAsync();

            // Assert
            result.Should().HaveCount(10);
            result.First().Should().BeEquivalentTo(expectedGame, options => options.ComparingByMembers<Game>());
        }
    }
}
