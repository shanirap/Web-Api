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

        UsersDBContext dBContext;
        public ProductsData(UsersDBContext usersDBContext)
        {
            dBContext = usersDBContext;
        }
        public async Task<List<Product>> getProducts()
        {
            return await dBContext.Products.ToListAsync<Product>();
        }

    }
}
