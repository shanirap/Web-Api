using Entities;
using Microsoft.EntityFrameworkCore;
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

    public class OrdersDataUnitTests
    {
        [Fact]
        public async Task getOrders_ReturnsAllOrders()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { OrderId = 1, OrderDate = DateTime.Now, OrderSum = 100, UserId = 1 },
                new Order { OrderId = 2, OrderDate = DateTime.Now, OrderSum = 200, UserId = 2 }
            };

            var mockContext = new Mock<UsersDBContext>(new Microsoft.EntityFrameworkCore.DbContextOptions<UsersDBContext>());
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);

            var repo = new OrderData(mockContext.Object);

            // Act
            var result = await repo.getOrder();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(100, result[0].OrderSum);
            Assert.Equal(200, result[1].OrderSum);
        }

        [Fact]
        public async Task addOrder_AddsOrderSuccessfully()
        {
            // Arrange
            var newOrder = new Order { OrderId = 3, OrderDate = DateTime.Now, OrderSum = 300, UserId = 3 };

            var mockContext = new Mock<UsersDBContext>(new Microsoft.EntityFrameworkCore.DbContextOptions<UsersDBContext>());
            var mockDbSet = new Mock<DbSet<Order>>();
            mockContext.Setup(x => x.Orders).Returns(mockDbSet.Object);

            var repo = new OrderData(mockContext.Object);

            // Act
            await repo.Add(newOrder);

            // Assert
            mockDbSet.Verify(x => x.AddAsync(newOrder, default), Times.Once);
            mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }
    }
}

