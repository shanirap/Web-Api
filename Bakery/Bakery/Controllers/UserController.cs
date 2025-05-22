using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;
        public UserController(IUserServices _userServices)
        {
            userServices = _userServices;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await userServices.getUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
             User user = await userServices.getUserId(id);
            if(user!=null)
            {
                return Ok(User);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost]
        [Route("checkPassword")]
        public int CheckPassword([FromBody] String password)
        {
            return userServices.validatepasswordStrong(password);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
            if (user is null)
                return StatusCode(400, "user is required");
            try
            {
                await userServices.register(user);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            catch (HttpStatusException e)
            {
                return StatusCode((int)e.StatusCode, e.Message);
            }
         
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginUser loginUser)
        {
            try
            {
                User user =await userServices.login(loginUser);
                return Ok(user);
            }
             catch(HttpStatusException e)
            {
                return StatusCode((int)e.StatusCode, e.Message);
            }
         
        }



        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put( int id, [FromBody]  User user)
        {
            try
            {
                await userServices.update(id, user);
                return Ok(user);
            }
            catch (HttpStatusException e)
            {
                return StatusCode((int)e.StatusCode, e.Message);
            }

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
