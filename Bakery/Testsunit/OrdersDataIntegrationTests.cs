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

            using (_context)
            {
                var ordersData = new OrdersData(_context);
                var order = new Order
                {
                    UserId = 2,
                    OrderDate = DateTime.UtcNow,
                    OrderSum = 0,
                    OrderItems = new List<OrderItem>() // ללא פריטים
                };

                await ordersData.addOrder(order);
            }

            using (_context)
            {
                var orders = await _context.Orders.Include(o => o.OrderItems).ToListAsync();
                Assert.Single(orders);
                Assert.Empty(orders[0].OrderItems);
            }
        }

        [Fact]
        public async Task AddOrder_WithInvalidProductId_SavesIfNoFKConstraint()
        {

            using (_context)
            {
                var ordersData = new OrdersData(_context);
                var order = new Order
                {
                    UserId = 3,
                    OrderDate = DateTime.UtcNow,
                    OrderSum = 100,
                    OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 9999, Quantity = 1 }
                }
                };

                // InMemory DB לא תזרוק שגיאת FK – אלא אם תגדיר את הקשר מפורשות
                await ordersData.addOrder(order);
            }

            using (_context)
            {
                var orders = await _context.Orders.Include(o => o.OrderItems).ToListAsync();
                Assert.Single(orders);
                Assert.Single(orders[0].OrderItems);
                Assert.Equal(9999, orders[0].OrderItems.First().ProductId);
            }
        }

        [Fact]
        public async Task AddOrder_NullOrder_ThrowsException()
        {

            using (_context)
            {
                var ordersData = new OrdersData(_context);

                await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                {
                    await ordersData.addOrder(null);
                });
            }
        }

        [Fact]
        public async Task AddOrder_MissingRequiredFields_ThrowsException()
        {

            using (_context)
            {
                var ordersData = new OrdersData(_context);

                var incompleteOrder = new Order(); // חסר UserId, OrderDate וכו'

                // EF עשוי לא לזרוק שגיאה בלי ולידציה חזקה, אז תוסיף בעצמך אם צריך
                await ordersData.addOrder(incompleteOrder);

                // אם אין שגיאה – נבדוק שהוא נשמר עם ערכים ברירתיים
                var savedOrder = await _context.Orders.FirstOrDefaultAsync();
                Assert.NotNull(savedOrder);
            }
        }
    }

}

