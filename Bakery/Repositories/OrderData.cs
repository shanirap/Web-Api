using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
   public class OrderData : IOrderData
    {
        UsersDBContext dBContext;
        public OrderData(UsersDBContext udBContext)
        {
            dBContext = udBContext;
        }
        public async Task<List<Order>> getOrder()//funtion's name starts with a capital letter - change it
        {
            return await dBContext.Orders.ToListAsync<Order>();
        }
        public async Task Add(Order order)
        {
            try
            {
                await dBContext.Orders.AddAsync(order);
                await dBContext.SaveChangesAsync();
                //return order;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
