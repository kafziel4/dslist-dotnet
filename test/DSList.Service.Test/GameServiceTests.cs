﻿using DSList.Service.Services;

namespace DSList.Service.Test
{
    public class GameServiceTests
    {
        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnGameMinDtoList()
        {
            // Arrange
            var service = new GameService();

            // Act
            var result = await service.FindAllAsync();

            // Assert
        }
    }
}
