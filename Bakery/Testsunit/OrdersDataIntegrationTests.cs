using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
   

using Xunit;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities;
using Bakery;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class OrdersDataEdgeCasesTests : IClassFixture<DatabaseFixture>
    {
        private readonly BakeryDBContext _context;
        private readonly OrdersData _ordersData;
        public OrdersDataEdgeCasesTests(DatabaseFixture fixture)
        {
            _context = fixture.Context;
            _ordersData = new OrdersData(_context);
        }

      

        [Fact]
        public async Task AddOrder_WithoutItems_SuccessfullySaved()
        {


                var ordersData = new OrdersData(_context);
                var user = new User
                {
                    Username = "testuser",
                    Password = "password123",
                    Firstname = "Test",
                    Lastname = "User"
                };
                var order = new Order
                {
                    UserId = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderSum = 0,
                    OrderItems = new List<OrderItem>() // ללא פריטים
                };
            _context.Users.Add(user);
            await _context.SaveChangesAsync(); // שמירת המשתמש כדי לקבל UserId תקין

            await ordersData.addOrder(order);
            

      
                var orders = await _context.Orders.Include(o => o.OrderItems).ToListAsync();
                Assert.Single(orders);
                Assert.Empty(orders[0].OrderItems);
            
        }

        [Fact]
        public async Task AddOrder_WithInvalidProductId_SavesIfNoFKConstraint()
        {
                var ordersData = new OrdersData(_context);
            var user = new User
            {
                Username = "testuser",
                Password = "password123",
                Firstname = "Test",
                Lastname = "User"
            };
            var product = new Product
            {
                ProductName = "Test Product",
                Price = 10,
                CategoryId = 1 // נניח שיש קטגוריה עם ID זה
            };
            var category = new Catgory
            {
                CatgoryName = "Test Category"
            };
            var order = new Order
                {
                    UserId = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderSum = 100,
                    OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quantity = 1 }
                }
                };

            _context.Catgories.Add(category);
            _context.Products.Add(product);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // InMemory DB לא תזרוק שגיאת FK – אלא אם תגדיר את הקשר מפורשות
            await ordersData.addOrder(order);
            

           
                var orders = await _context.Orders.Include(o => o.OrderItems).ToListAsync();
                Assert.Single(orders);
                Assert.Single(orders[0].OrderItems);
                Assert.Equal(1, orders[0].OrderItems.First().ProductId);
            
        }

        [Fact]
        public async Task AddOrder_NullOrder_ThrowsException()
        {
        
                var ordersData = new OrdersData(_context);

                await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                {
                    await ordersData.addOrder(null);
                });
        }

        [Fact]
        public async Task AddOrder_MissingRequiredFields_ThrowsException()
        {
            var ordersData = new OrdersData(_context);
            var incompleteOrder = new Order(); // חסר UserId

            await Assert.ThrowsAsync<DbUpdateException>(() =>
                ordersData.addOrder(incompleteOrder)
            );
        }

    }

}

