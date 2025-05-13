using Entities;

namespace Repositories
{
    public interface IProductsData
    {
        Task<List<Product>> getProducts();
    }
}