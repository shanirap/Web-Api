using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testsunit
{

    public class CategoriesDataUnitTests
    {
        [Fact]
        public async Task getCatgories_ReturnsAllCategories()
        {
            // Arrange
            var categories = new List<Catgory>
            {
                new Catgory { Id = 1, CatgoryName = "Breads" },
                new Catgory { Id = 2, CatgoryName = "Cakes" }
            };

            var mockContext = new Mock<BakeryDBContext>(new Microsoft.EntityFrameworkCore.DbContextOptions<BakeryDBContext>());
            mockContext.Setup(x => x.Catgories).ReturnsDbSet(categories);

            var repo = new CategoriesData(mockContext.Object);

            // Act
            var result = await repo.getCatgories();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Breads", result[0].CatgoryName);
            Assert.Equal("Cakes", result[1].CatgoryName);
        }
    }
}