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
    public class UserServices
    {

        UsersData usersData = new UsersData();

        public int validatepasswordStrong(string password)
        {
            var zxcvbnResult=Zxcvbn.Core.EvaluatePassword(password);
            return zxcvbnResult.Score;
        }
        public void register(User user)
        {
            try
            {
                if (validatepasswordStrong(user.Password)>2)
                {
                    usersData.Register(user);
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

        public User login(LoginUser user)
        {
            try
            {
                User user1 = usersData.Login(user);
                return user1;
            }
            catch (HttpStatusException e)
            {

                throw new HttpStatusException(e.StatusCode, e.Message);
            }
        }

        public void update(int id, User user)
        {
            try
            {
                usersData.Update(id, user);
            }
            catch (HttpStatusException e)
            {

                throw new HttpStatusException(e.StatusCode, e.Message);
            }
        }
    }
}
