using AutoMapper;
using DSList.Data.Entities;
using DSList.Data.Interfaces;
using DSList.Data.Projections;
using DSList.Service.Dtos;
using DSList.Service.Profiles;
using DSList.Service.Services;
using FluentAssertions;
using Moq;

namespace DSList.Service.Test
{
    public class GameServiceTests
    {
        private readonly GameService _service;
        private readonly Mock<IGameRepository> _mockRepository;

        public GameServiceTests()
        {
            _mockRepository = new Mock<IGameRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfile<GameProfile>());
            var mapper = new Mapper(mapperConfiguration);

            _service = new GameService(_mockRepository.Object, mapper);
        }

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
            _mockRepository.Setup(_ => _.FindAllAsync()).ReturnsAsync(gameList);

            var expectedFirstGame = new GameMinDto
            {
                Id = 1,
                Title = "Mass Effect Trilogy",
                Year = 2012,
                ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!"
            };

            // Act
            var result = await _service.FindAllAsync();

            // Assert
            result.Should().HaveCount(10);
            result.First().Should().BeEquivalentTo(expectedFirstGame, options => options.ComparingByMembers<GameMinDto>());
        }

        [Fact]
        public async Task FindByIdAsync_Invoke_ShouldReturnGameDto()
        {
            // Arrange
            var game = new Game
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
            _mockRepository.Setup(_ => _.FindByIdAsync(1)).ReturnsAsync(game);

            var expectedGame = new GameDto
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
            var result = await _service.FindByIdAsync(1);

            // Assert
            result.Should().BeEquivalentTo(expectedGame, options => options.ComparingByMembers<GameDto>());
        }

        [Fact]
        public async Task FindByListAsync_Invoke_ShouldReturnGameMinDtoList()
        {
            // Arrange
            var gameList = new List<GameMinProjection>();
            for (int i = 1; i <= 5; i++)
            {
                gameList.Add(new GameMinProjection
                {
                    Id = i,
                    Title = "Mass Effect Trilogy",
                    Year = 2012,
                    ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                    ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!",
                    Position = i - 1
                });
            }
            _mockRepository.Setup(_ => _.SearchByListAsync(1)).ReturnsAsync(gameList);

            var expectedFirstGame = new GameMinDto
            {
                Id = 1,
                Title = "Mass Effect Trilogy",
                Year = 2012,
                ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!"
            };

            // Act
            var result = await _service.FindByListAsync(1);

            // Assert
            result.Should().HaveCount(5);
            result.First().Should().BeEquivalentTo(expectedFirstGame, options => options.ComparingByMembers<GameMinDto>());
        }
    }
}
