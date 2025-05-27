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
            var categories = new List<Category>
            {
                new Category { Id = 1, CategoryName = "Breads" },
                new Category { Id = 2, CategoryName = "Cakes" }
            };

            var mockContext = new Mock<UsersDBContext>(new Microsoft.EntityFrameworkCore.DbContextOptions<UsersDBContext>());
            mockContext.Setup(x => x.Categories).ReturnsDbSet(categories);

            var repo = new CategoriesData(mockContext.Object);

            // Act
            var result = await repo.getCategory();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Breads", result[0].CategoryName);
            Assert.Equal("Cakes", result[1].CategoryName);
        }
    }
}