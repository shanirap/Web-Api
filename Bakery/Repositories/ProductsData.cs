using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductsData : IProductsData
    {
        BakeryDBContext dBContext;
        public ProductsData(BakeryDBContext usersDBContext)
        {
            dBContext = usersDBContext;
        }

        public async Task<List<Product>> getProducts()
        {
            return await dBContext.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
