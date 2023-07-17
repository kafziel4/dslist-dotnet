using AutoMapper;
using DSList.Data.Entities;
using DSList.Data.Interfaces;
using DSList.Service.Dtos;
using DSList.Service.Profiles;
using DSList.Service.Services;
using FluentAssertions;
using Moq;

namespace DSList.Service.Test
{
    public class GameServiceTests
    {
        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnGameMinDtoList()
        {
            // Arrange
            var gameList = new List<Game>();
            for (int i = 1; i <= 10; i++)
            {
                gameList.Add(new Game
                {
                    Id = i,
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
                });
            }

            var repositoryMock = new Mock<IGameRepository>();
            repositoryMock.Setup(_ => _.FindAllAsync()).ReturnsAsync(gameList);

            var mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfile<GameProfile>());
            var mapper = new Mapper(mapperConfiguration);

            var service = new GameService(repositoryMock.Object, mapper);
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
