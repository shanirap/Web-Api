using Entities;

namespace Repositories
{
    public interface IOrderData
    {
        Task Add(Order order);
        Task<List<Order>> getOrder();
    }
}