using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class orderServices : IorderServices
    {
        private readonly IOrderData orderData;
        public orderServices(IOrderData _orderData)
        {
            orderData = _orderData;
        }

        public async Task<List<Order>> getOrder()
        {
            return await orderData.getOrder();
        }
        public async Task Add(Order order)
        {
            try
            {
                await orderData.Add(order);
            }
            catch (HttpStatusException e)
            {

                throw new HttpStatusException(e.StatusCode, e.Message);
            }
        }
    }
}
