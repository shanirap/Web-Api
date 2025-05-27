using DTOs;
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
        public async Task<ActionResult<List<OrderDto>>> Get()
        {
            return await ordersServices.getOrders();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task Post([FromBody]OrderDto order)
        {
                await ordersServices.addOrder(order); 
        }


    }
}
