using DSList.Data.DbContexts;
using DSList.Service.Dtos;
using DSList.Service.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net;
using System.Net.Http.Json;
using Testcontainers.PostgreSql;

namespace DSList.Test
{
    public class IntegrationTests : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder().Build();
        private HttpClient _client = null!;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var connectionString = _postgreSqlContainer.GetConnectionString();

            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<GameDbContext>));
                services.AddDbContext<GameDbContext>(options => options.UseNpgsql(connectionString));

                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<GameDbContext>();
                context.Database.EnsureCreated();
            });
        }

        [Fact]
        public async Task GetAllGamesEndpoint_WhenRequested_ShouldReturnOKAndGamesList()
        {
            // Arrange
            var expectedFirstGame = new GameMinDto
            {
                Id = 1,
                Title = "Mass Effect Trilogy",
                Year = 2012,
                ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!"
            };

            // Act
            var response = await _client.GetAsync("/api/games");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseObject = await response.Content.ReadFromJsonAsync<IEnumerable<GameMinDto>>();
            var gamesList = responseObject.Should().BeAssignableTo<IEnumerable<GameMinDto>>().Subject;
            gamesList.Should().HaveCount(10);
            gamesList.First().Should().BeEquivalentTo(expectedFirstGame, options => options.ComparingByMembers<GameMinDto>());
        }

        [Fact]
        public async Task GetGameByIdEndpoint_WhenRequested_ShouldReturnOKAndGame()
        {
            // Arrange
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
            var response = await _client.GetAsync("/api/games/1");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseObject = await response.Content.ReadFromJsonAsync<GameDto>();
            var game = responseObject.Should().BeAssignableTo<GameDto>().Subject;
            game.Should().BeEquivalentTo(expectedGame, options => options.ComparingByMembers<GameDto>());
        }

        [Fact]
        public async Task GetAllGameListsEndpoint_WhenRequested_ShouldReturnOKAndListOfGamesList()
        {
            // Arrange
            var expectedFirstGameList = new GameListDto
            {
                Id = 1,
                Name = "Aventura e RPG"
            };

            // Act
            var response = await _client.GetAsync("/api/lists");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseObject = await response.Content.ReadFromJsonAsync<IEnumerable<GameListDto>>();
            var gameLists = responseObject.Should().BeAssignableTo<IEnumerable<GameListDto>>().Subject;
            gameLists.Should().HaveCount(2);
            gameLists.First().Should().BeEquivalentTo(expectedFirstGameList, options => options.ComparingByMembers<GameListDto>());
        }

        public async Task InitializeAsync()
        {
            await _postgreSqlContainer.StartAsync();
            _client = CreateClient();
        }

        public new async Task DisposeAsync()
        {
            await _postgreSqlContainer.DisposeAsync();
        }
    }
}
