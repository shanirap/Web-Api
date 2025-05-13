using Bakery;
using Entities;

namespace Services
{
    public interface IUserServices
    {
        Task<List<User>> getAllUsers();
        Task<User> GetUserById(int id);
        Task<User> login(LoginUser user);
        Task Register(User user);
        Task update(int id, User user);
        int validatepasswordStrong(string password);
    }
}