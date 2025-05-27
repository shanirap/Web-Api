using DTOs;
using Entities;

namespace Services
{
    public interface IorderServices
    {
        Task Add(OrderDTO order);
        Task<List<OrderDTO>> getOrder();
    }
}