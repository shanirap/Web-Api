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
    public class orderController : ControllerBase
    {
        private readonly IorderServices OrderServices;//change to a lowercase letter
        public orderController(IorderServices _OrderServices)
        {
            OrderServices = _OrderServices;
        }
        // GET: api/<orderController>
        [HttpGet]
        public async Task<List<OrderDTO>> Get()
        {

            return await OrderServices.getOrder();
        }

       
        // POST api/<orderController>
        [HttpPost]
        public async Task Add([FromBody] OrderDTO order )
        {
           
              await OrderServices.Add(order);
             //return something - order, Ok() or CreatedAtAction() 
        }

      
    }
}
