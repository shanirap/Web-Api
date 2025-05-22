using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private readonly IorderServices OrderServices;
        public orderController(IorderServices _OrderServices)
        {
            OrderServices = _OrderServices;
        }
        // GET: api/<orderController>
        [HttpGet]
        public async Task<List<Order>> Get()
        {
            return await OrderServices.getOrder();
        }

        // GET api/<orderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<orderController>
        [HttpPost]
        public async Task Add([FromBody] Order order )
        {
           
              await OrderServices.Add(order);
 
        }

        // PUT api/<orderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<orderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
