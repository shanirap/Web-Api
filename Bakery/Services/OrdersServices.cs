using AutoMapper;
using DTOs;
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
        private readonly IMapper autoMapping;

        public OrdersServices(IOrdersData _ordersData, IMapper _autoMapping)
        {
            autoMapping = _autoMapping;
            ordersData = _ordersData;
        }

        public async Task<List<OrderDto>> getOrders()
        {
            List<Order> orders = await ordersData.getOrders();
            List<OrderDto> ordersDto = autoMapping.Map<List<OrderDto>>(orders);
            return ordersDto;
        }

        public async Task addOrder(OrderDto orderDto)
        {
            try
            {
                Order order = autoMapping.Map<Order>(orderDto);
                await ordersData.addOrder(order);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
