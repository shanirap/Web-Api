using Repositories;
using Entities;
using Bakery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ICategoriesData categoriesData;
        public CategoriesServices(ICategoriesData _categoriesData)
        {
            categoriesData = _categoriesData;
        }
        public async Task<List<Catgory>> getCategories()
        {
            return await categoriesData.getCatgories();
        }
    }
}
