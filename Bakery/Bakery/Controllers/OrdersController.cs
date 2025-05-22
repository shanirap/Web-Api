using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrdersServices ordersServices;
        public OrdersController(IOrdersServices _ordersServices)
        {
            ordersServices = _ordersServices;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return await ordersServices.getOrders();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task Post([FromBody]Order order)
        {
                await ordersServices.addOrder(order); 
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
