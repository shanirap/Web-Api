using DTOs;
using Entities;

namespace Services
{
    public interface IProductsServices
    {
        Task<List<ProductDTO>> getProducts();
    }
}