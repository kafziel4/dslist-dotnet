using DSList.Data.Interfaces;
using DSList.Data.Repositories;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace DSList.API.Test
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void RegisterDataServices_EnvironmentIsDevelopment_ShouldRegisterGameDataServices()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.RegisterDataServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Assert
            var service = serviceProvider.GetService<IGameRepository>();
            service.Should().NotBeNull();
            service.Should().BeOfType<GameReposiotry>();

        }
    }
}
