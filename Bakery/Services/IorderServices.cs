using Entities;

namespace Services
{
    public interface IorderServices
    {
        Task Add(Order order);
        Task<List<Order>> getOrder();
    }
}