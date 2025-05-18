using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices categoriesServices;

        public CategoriesController(ICategoriesServices _categoriesServices)
        {
            categoriesServices = _categoriesServices;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async  Task<ActionResult<List<Catgory>>> Get()
        {
            return await categoriesServices.getCategories();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
