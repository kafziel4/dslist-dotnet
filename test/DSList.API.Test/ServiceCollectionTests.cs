using DSList.Data.Interfaces;
using DSList.Data.Repositories;
using DSList.Service.Interfaces;
using DSList.Service.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace DSList.API.Test
{
    public class ServiceCollectionTests
    {
        private readonly ServiceCollection _serviceCollection;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _mockEnvironment;

        public ServiceCollectionTests()
        {
            _serviceCollection = new ServiceCollection();
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string, string>
                    { { "ConnectionStrings:GameDBConnectionString", "AnyString" } })
                .Build();
            _mockEnvironment = Substitute.For<IWebHostEnvironment>();
        }

        [Theory]
        [InlineData("Development")]
        [InlineData("Production")]
        public void RegisterAppServices_Invoke_ShouldRegisterGameRepository(string environment)
        {
            // Arrange
            _mockEnvironment.EnvironmentName.Returns(environment);

            // Act
            _serviceCollection.RegisterAppServices(_configuration, _mockEnvironment);
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            // Assert
            var service = serviceProvider.GetService<IGameRepository>();
            service.Should().NotBeNull();
            service.Should().BeOfType<GameRepository>();
        }

        [Fact]
        public void RegisterAppServices_Invoke_ShouldRegisterGameService()
        {
            // Act
            _serviceCollection.RegisterAppServices(_configuration, _mockEnvironment);
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            // Assert
            var service = serviceProvider.GetService<IGameService>();
            service.Should().NotBeNull();
            service.Should().BeOfType<GameService>();
        }

        [Theory]
        [InlineData("Development")]
        [InlineData("Production")]
        public void RegisterAppServices_Invoke_ShouldRegisterGameListRepository(string environment)
        {
            // Arrange
            _mockEnvironment.EnvironmentName.Returns(environment);

            // Act
            _serviceCollection.RegisterAppServices(_configuration, _mockEnvironment);
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            // Assert
            var service = serviceProvider.GetService<IGameListRepository>();
            service.Should().NotBeNull();
            service.Should().BeOfType<GameListRepository>();
        }

        [Fact]
        public void RegisterAppServices_Invoke_ShouldRegisterGameListService()
        {
            // Act
            _serviceCollection.RegisterAppServices(_configuration, _mockEnvironment);
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            // Assert
            var service = serviceProvider.GetService<IGameListService>();
            service.Should().NotBeNull();
            service.Should().BeOfType<GameListService>();
        }
    }
}
