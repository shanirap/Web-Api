using Entities;

namespace Repositories
{
    public interface IOrdersData
    {
        Task addOrder(Order order);
        Task<List<Order>> getOrders();
    }
}