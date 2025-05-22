using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrdersServices : IOrdersServices
    {
        private readonly IOrdersData ordersData;

        public OrdersServices(IOrdersData _ordersData)
        {
            ordersData = _ordersData;
        }

        public async Task<List<Order>> getOrders()
        {
            return await ordersData.getOrders();
        }

        public async Task addOrder(Order order)
        {
            try
            {
                await ordersData.addOrder(order);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
