using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices productsServices;
        public ProductsController(IProductsServices _ProductsServices)
        {
            productsServices = _ProductsServices;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get()
        {
            return await productsServices.getProducts();
        }
    }
}
