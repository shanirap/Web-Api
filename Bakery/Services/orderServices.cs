using Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Services
{
    public class orderServices : IorderServices
    {
        private readonly IOrderData orderData;
        private readonly IMapper mapper;
        public orderServices(IOrderData _orderData,IMapper _mapper)
        {
            orderData = _orderData;
            mapper = _mapper;
        }

        public async Task<List<OrderDTO>> getOrder()
        {
            List<Order> l=await orderData.getOrder();
            List<OrderDTO> ll = mapper.Map<List<Order>, List<OrderDTO>>(l);
            return ll;
        }
        public async Task Add(OrderDTO orderDTO)
        {
            try
            {
                Order order = mapper.Map<Order>(orderDTO);
                await orderData.Add(order);
            }
            catch (HttpStatusException e)
            {

                throw new HttpStatusException(e.StatusCode, e.Message);
            }
        }
    }
}
