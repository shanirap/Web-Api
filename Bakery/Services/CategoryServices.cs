using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;

using Bakery;
using AutoMapper;
using DTOs;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoriesData categoriesData;
        private readonly IMapper mapper;
        public CategoryServices(ICategoriesData _categoriesData, IMapper _mapper)
        {
            categoriesData = _categoriesData;
            mapper = _mapper;
        }
        public async Task<List<CategoryDTO>> getCategory()
        {
            List<Category> l= await categoriesData.getCategory();
            List<CategoryDTO> ll = mapper.Map<List<Category>, List<CategoryDTO>>(l);
            return ll;
        }
    }
}
