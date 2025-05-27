using Bakery;
using DTOs;
using Entities;

namespace Services
{
    public interface IUserServices
    {
        Task<UserDto> getUserId(int id);
        Task<List<UserDto>> getUsers();
        Task<UserDto> login(LoginUserDto user);
        Task register(RegisterUserDto user);
        Task update(int id, RegisterUserDto user);
        int validatepasswordStrong(string password);
    }
}