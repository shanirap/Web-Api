using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;
using Bakery;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoriesData categoriesData;
        public CategoryServices(ICategoriesData _categoriesData)
        {
            categoriesData = _categoriesData;
        }
        public async Task<List<Category>> getCategory()
        {
            return await categoriesData.getCategory();
        }
    }
}
