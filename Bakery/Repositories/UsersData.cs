using Bakery;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsersData : IUsersData
    {
        UsersDBContext dBContext;
        public UsersData(UsersDBContext usersDBContext)
        {
            dBContext = usersDBContext;
        }
        public async Task Register(User user)
        {
            try
            {
                if (await dBContext.Users.AnyAsync(u => user.Username == u.Username && user.Password == u.Password))
                    throw new HttpStatusException(409, "username already exist");
                await dBContext.Users.AddAsync(user);
                await dBContext.SaveChangesAsync();
    
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> Login(LoginUser loginUser)
        {
            return await dBContext.Users.FirstAsync(user => user.Username == loginUser.UserName && user.Password == loginUser.Password);
        }
        public async Task Update(int id, User user)
        {
            try
            {
                dBContext.Users.Update(user);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<User> getUserById(int id)
        {
            return await dBContext.Users.FindAsync(id);
        }
        public async Task<List<User>> getAllUsers()
        {
            return await dBContext.Users.ToListAsync<User>();
        }


    }
}
