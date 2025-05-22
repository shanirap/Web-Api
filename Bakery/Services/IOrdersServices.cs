using Entities;

namespace Services
{
    public interface IOrdersServices
    {
        Task addOrder(Order order);
        Task<List<Order>> getOrders();
    }
}