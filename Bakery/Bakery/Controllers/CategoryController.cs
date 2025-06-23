using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
//delete unused code
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<CategoryDTO>> Get()
        {
            return await _categoryServices.getCategory();
        }
    
    }
}