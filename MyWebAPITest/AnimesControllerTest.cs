using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MyWebAPI.Controllers;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace MyWebAPITest
{
    public class AnimesControllerTest
    {        
        [Fact]
        public void GetAll_WithExistingItems_ReturnsOkResultWithItems()
        {
            // Arrange

            var animes = new List<Anime>()
            {
                new Anime("Naruto Clássico", "Descrição teste", new DateTime()),
                new Anime("Naruto Shippuden", "Descrição teste", new DateTime()),
                new Anime("Boruto", "Descrição teste", new DateTime()),
            };

            var mockRepository = new Mock<IBaseRepository<Anime>>();
            var mockLogger = new Mock<ILogger<AnimesController>>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(r => r.GetAll()).Returns(animes);

            var controller = new AnimesController(mockLogger.Object, mockRepository.Object, mockMapper.Object);

            // Act


            // Assert
        }

        [Fact]
        public void GetAll_WithoutExistingItems_ReturnsOkResultEmpty()
        {
            // Arrange


            // Act


            // Assert
        }
    }
}
