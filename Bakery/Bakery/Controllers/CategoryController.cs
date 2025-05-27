using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices CategoryServices;
        public CategoryController(ICategoryServices _CategoryServices)
        {
            CategoryServices = _CategoryServices;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<CategoryDTO>> Get()
        {
            return await CategoryServices.getCategory();
        }
    
    }
}