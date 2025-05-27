using AutoMapper;
using Bakery;
using DTOs;
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
        private readonly IMapper mapper;
        public UserServices(IUsersData _usersData, IMapper _mapper)
        {
            usersData = _usersData;
            mapper = _mapper;

        }

        public int validatepasswordStrong(string password)
        {
            var zxcvbnResult = Zxcvbn.Core.EvaluatePassword(password);
            return zxcvbnResult.Score;
        }
        public async Task Register(RegisterUserDTO RuserDTO)
        {
            try
            {
                if (validatepasswordStrong(RuserDTO.PASSWORD) > 2)
                {
                    User user = mapper.Map<User>(RuserDTO);
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

        public async Task<UserDTO> login(LoginUserDTO luserDTO)
        {
            try
            {
               User loginUser = mapper.Map<User>(luserDTO);
                User user = await usersData.Login(loginUser);
                UserDTO userDTO = mapper.Map<UserDTO>(user);
                return userDTO;
            }
            catch (HttpStatusException e)
            {

                throw new HttpStatusException(e.StatusCode, e.Message);
            }
        }

        public async Task update(int id, RegisterUserDTO userDTO)
        {
            try
            {
                User user = mapper.Map<User>(userDTO);
                await usersData.Update(id, user);
            }
            catch (HttpStatusException e)
            {
                throw new HttpStatusException(e.StatusCode, e.Message);
            }
        }
        public async Task<UserDTO> GetUserById(int id)
        {

            User user = await usersData.getUserById(id);
            UserDTO userDTO = mapper.Map<UserDTO>(user);
            return userDTO;
        }
        public async Task<List<UserDTO>> getAllUsers()
        {

            List<User> l = await usersData.getAllUsers();
            List<UserDTO> ll = mapper.Map<List<UserDTO>>(l);
            return ll;
        }
    }
}
