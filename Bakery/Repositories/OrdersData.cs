using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrdersData : IOrdersData
    {
        BakeryDBContext dBContext;

        public OrdersData(BakeryDBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        public async Task<List<Order>> getOrders()
        {
            return await dBContext.Orders.ToListAsync<Order>();
        }
        public async Task addOrder(Order order)
        {
            try
            {
                await dBContext.Orders.AddAsync(order);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
