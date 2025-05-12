using Bakery;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly IUsersData usersData;
        public UserServices(IUsersData _usersData)
        {
            usersData = _usersData;
        }

        public int validatepasswordStrong(string password)
        {
            var zxcvbnResult = Zxcvbn.Core.EvaluatePassword(password);
            return zxcvbnResult.Score;
        }
        public async Task register(User user)
        {
            try
            {
                if (validatepasswordStrong(user.Password) > 2)
                {
                    await usersData.Register(user);
                }
                else
                {
                    throw new HttpStatusException(400, "password is not strong enough");
                }
            }
            catch (HttpStatusException e)
            {

                throw new HttpStatusException(e.StatusCode, e.Message);
            }

        }

        public async Task<User> login(LoginUser user)
        {
            try
            {
                User user1 = await usersData.Login(user);
                return user1;
            }
            catch (HttpStatusException e)
            {

                throw new HttpStatusException(e.StatusCode, e.Message);
            }
        }

        public async Task update(int id, User user)
        {
            try
            {
                await usersData.Update(id, user);
            }
            catch (HttpStatusException e)
            {

                throw new HttpStatusException(e.StatusCode, e.Message);
            }
        }

        public async Task<User> getUserId(int id)
        {
            return await usersData.getUserId(id);
        }

        public async Task<List<User>> getUsers()
        {
            return await usersData.getUsers();
        }
    }
}
