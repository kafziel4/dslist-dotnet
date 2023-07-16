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

            // Assert
        }
    }
}
