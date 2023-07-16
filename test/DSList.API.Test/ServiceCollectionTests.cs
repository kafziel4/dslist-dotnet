using DSList.Data.Interfaces;
using DSList.Data.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace DSList.API.Test
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void RegisterDataServices_EnvironmentIsDevelopment_ShouldRegisterGameDataServices()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string, string> {
                        {"ConnectionStrings:GameDBConnectionString", "AnyString"}})
                .Build();
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment.Setup(_ => _.EnvironmentName).Returns("Development");

            // Act
            serviceCollection.RegisterDataServices(configuration, mockEnvironment.Object);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Assert
            var service = serviceProvider.GetService<IGameRepository>();
            service.Should().NotBeNull();
            service.Should().BeOfType<GameReposiotry>();

        }
    }
}
