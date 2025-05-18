using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductsData productsData;
        public ProductsServices(IProductsData _productsData)
        {
            productsData = _productsData;
        }
        public async Task<List<Product>> getProducts()
        {
            return await productsData.getProducts();
        }
    }
}
