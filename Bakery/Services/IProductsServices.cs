using Entities;

namespace Services
{
    public interface IProductsServices
    {
        Task<List<Product>> getProducts();
    }
}