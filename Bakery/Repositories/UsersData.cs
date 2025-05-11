using Bakery;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsersData
    {
        public void Register(User user)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User userFromFile = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (userFromFile.UserName == user.UserName)
                        throw new HttpStatusException (409,"Duplicate");
                            //return Conflict();
                }
            }

            int numberOfUsers = System.IO.File.Exists(path) ? System.IO.File.ReadLines(path).Count() : 0;
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            //return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }
        public User Login(LoginUser loginUser)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.UserName == loginUser.UserName && user.Password == loginUser.Password)
                    {
                        //return Ok(new { userId = user.UserId });
                        //return Ok(user);
                        return user;
                    }
                }
            }
            //return Unauthorized("Incorrect userName or password");
            throw new HttpStatusException(401, "Unauthorized");
        }
        public void Update(int id, User user)
        {
            {
                User newUser = new User();
                //User oldUser = Get(id);
                if (user.FirstName != null)
                    newUser.FirstName = user.FirstName;
                //else
                //    newUser.FirstName = oldUser.FirstName;
                if (user.LastName != null)
                    newUser.LastName = user.LastName;
                //else
                //    newUser.LastName = oldUser.LastName;
                if (user.Password != null)
                    newUser.Password = user.Password;
                //else
                //    newUser.Password = oldUser.Password;
                if (user.UserName != null)
                    newUser.UserName = user.UserName;
                //else
                //    newUser.UserName = oldUser.UserName;
                newUser.UserId = id;



                string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");

                string textToReplace = string.Empty;
                using (StreamReader reader = System.IO.File.OpenText(path))
                {
                    string currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {

                        User userFromFile = JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (userFromFile.UserId == id)
                            textToReplace = currentUserInFile;
                    }
                }

                if (textToReplace != string.Empty)
                {
                    string text = System.IO.File.ReadAllText(path);
                    text = text.Replace(textToReplace, JsonSerializer.Serialize(newUser));
                    System.IO.File.WriteAllText(path, text);
                }
                else
                {
                    throw new HttpStatusException(404, "user not found");
                }
            }
        }
    }
}
