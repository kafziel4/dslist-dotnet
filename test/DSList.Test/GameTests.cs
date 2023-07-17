using DSList.Data.DbContexts;
using DSList.Service.Dtos;
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
    public class GameTests : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder().Build();

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
            var client = CreateClient();
            var expectedFirstGame = new GameMinDto
            {
                Id = 1,
                Title = "Mass Effect Trilogy",
                Year = 2012,
                ImgUrl = "https://raw.githubusercontent.com/devsuperior/java-spring-dslist/main/resources/1.png",
                ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit esse officiis corrupti unde repellat non quibusdam! Id nihil itaque ipsum!"
            };

            // Act
            var response = await client.GetAsync("/api/games");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseObject = await response.Content.ReadFromJsonAsync<IEnumerable<GameMinDto>>();
            var gamesList = responseObject.Should().BeAssignableTo<IEnumerable<GameMinDto>>().Subject;
            gamesList.Should().HaveCount(10);
            gamesList.First().Should().BeEquivalentTo(expectedFirstGame, options => options.ComparingByMembers<GameMinDto>());
        }

        public async Task InitializeAsync()
        {
            await _postgreSqlContainer.StartAsync();
        }

        public new async Task DisposeAsync()
        {
            await _postgreSqlContainer.DisposeAsync();
        }
    }
}
