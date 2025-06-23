using AutoMapper;
using DTOs;
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
        private readonly IMapper mapper;
        public ProductsServices(IProductsData _productsData, IMapper _mapper)
        {
            productsData = _productsData;
            mapper = _mapper;
        }
        public async Task<List<ProductDTO>> getProducts()
        {
            List<Product> l=await productsData.getProducts();//Change the variable name.
            return mapper.Map< List<Product>,List<ProductDTO>>(l);//Change the variable name.
        }
    }
}
