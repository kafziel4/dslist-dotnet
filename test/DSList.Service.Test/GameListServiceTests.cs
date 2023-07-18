﻿using AutoMapper;
using DSList.Data.Entities;
using DSList.Data.Interfaces;
using DSList.Service.DTOs;
using DSList.Service.Profiles;
using DSList.Service.Services;
using FluentAssertions;
using Moq;

namespace DSList.Service.Test
{
    public class GameListServiceTests
    {
        [Fact]
        public async Task FindAllAsync_Invoke_ShouldReturnListOfGameListDto()
        {
            // Arrange
            var mockRepository = new Mock<IGameListRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfile<GameListProfile>());
            var mapper = new Mapper(mapperConfiguration);

            var service = new GameListService(mockRepository.Object, mapper);

            var listOfGameList = new List<GameList>();
            for (int i = 1; i <= 2; i++)
            {
                listOfGameList.Add(new GameList
                {
                    Id = i,
                    Name = "Aventura e RPG"
                });
            }
            mockRepository.Setup(_ => _.FindAllAsync()).ReturnsAsync(listOfGameList);

            var expectedFirstGameList = new GameListDto
            {
                Id = 1,
                Name = "Aventura e RPG"
            };

            // Act          
            var result = await service.FindAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.First().Should().BeEquivalentTo(expectedFirstGameList, options => options.ComparingByMembers<GameListDto>());
        }
    }
}