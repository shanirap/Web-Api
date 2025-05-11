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
        UserServices userServices = new UserServices();
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");

            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return null; //write in c# code


        }
        [HttpPost]
        [Route("checkPassword")]

        public int CheckPassword([FromBody] String password)
        {
            return userServices.validatepasswordStrong(password);
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<User> Register([FromBody] User user)
        {
            try
            {
                userServices.register(user);
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
            catch(HttpStatusException e)
            {
                return StatusCode((int)e.StatusCode, e.Message);
            }
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
            //using (StreamReader reader = System.IO.File.OpenText(path))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {
            //        User userFromFile = JsonSerializer.Deserialize<User>(currentUserInFile);

            //        if (userFromFile.UserName == user.UserName)
            //            return Conflict();
                        
            //    }
            //}

            //int numberOfUsers = System.IO.File.Exists(path) ? System.IO.File.ReadLines(path).Count() : 0;
            //user.UserId = numberOfUsers + 1;
            //string userJson = JsonSerializer.Serialize(user);
            //System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            //return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }


        [HttpPost]
        [Route("login")]
        public ActionResult<User> Login([FromBody] LoginUser loginUser)
        {
            try
            {
                User user = userServices.login(loginUser);
                return Ok(user);
            }
             catch(HttpStatusException e)
            {
                return StatusCode((int)e.StatusCode, e.Message);
            }
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
            //using (StreamReader reader = System.IO.File.OpenText(path))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {
            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);

            //        if (user.UserName == loginUser.UserName && user.Password == loginUser.Password) {
            //            //return Ok(new { userId = user.UserId });
            //            return Ok(user);
            //        }
            //    }
            //}
            //return Unauthorized("Incorrect userName or password");
            //return Ok();
        }



        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put( int id, [FromBody]  User user)
        {
            try
            {
                userServices.update(id, user);
                return Ok(user);
            }
            catch (HttpStatusException e)
            {
                return StatusCode((int)e.StatusCode, e.Message);
            }

            //User newUser = new Bakery.User();
            ////User oldUser = Get(id);
            //if (user.FirstName!=null)
            //    newUser.FirstName = user.FirstName;
            ////else
            ////    newUser.FirstName = oldUser.FirstName;
            //if (user.LastName != null)
            //    newUser.LastName = user.LastName;
            ////else
            ////    newUser.LastName = oldUser.LastName;
            //if (user.Password != null)
            //    newUser.Password = user.Password;
            ////else
            ////    newUser.Password = oldUser.Password;
            //if (user.UserName != null)
            //    newUser.UserName = user.UserName;
            ////else
            ////    newUser.UserName = oldUser.UserName;
            //newUser.UserId = id;



            //string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");

            //string textToReplace = string.Empty;
            //using (StreamReader reader = System.IO.File.OpenText(path))
            //{
            //    string currentUserInFile;
            //    while ((currentUserInFile = reader.ReadLine()) != null)
            //    {

            //        User userFromFile = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (userFromFile.UserId == id)
            //            textToReplace = currentUserInFile;
            //    }
            //}

            //if (textToReplace != string.Empty)
            //{
            //    string text = System.IO.File.ReadAllText(path);
            //    text = text.Replace(textToReplace, JsonSerializer.Serialize(newUser));
            //    System.IO.File.WriteAllText(path, text);
            //}

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
