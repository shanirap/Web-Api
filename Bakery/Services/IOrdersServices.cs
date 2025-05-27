using DTOs;
using Entities;

namespace Services
{
    public interface IOrdersServices
    {
        Task addOrder(OrderDto order);
        Task<List<OrderDto>> getOrders();
    }
}