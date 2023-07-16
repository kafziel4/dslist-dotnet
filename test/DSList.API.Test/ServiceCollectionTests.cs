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
        [Theory]
        [InlineData("Development")]
        [InlineData("Production")]
        public void RegisterDataServices_Invoke_ShouldRegisterGameDataServices(string environment)
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string, string> {
                        {"ConnectionStrings:GameDBConnectionString", "AnyString"}})
                .Build();
            var mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment.Setup(_ => _.EnvironmentName).Returns(environment);

            // Act
            serviceCollection.RegisterDataServices(configuration, mockEnvironment.Object);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Assert
            var service = serviceProvider.GetService<IGameRepository>();
            service.Should().NotBeNull();
            service.Should().BeOfType<GameReposiotry>();
        }

        [Fact]
        public void RegisterBusinessServices_Invoke_ShouldRegisterGameBusinessServices()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.RegisterBusinessServices();

            // Assert
        }
    }
}
