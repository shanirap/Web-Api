using Bakery;
using Entities;

namespace Services
{
    public interface IUserServices
    {
        Task<User> getUserId(int id);
        Task<List<User>> getUsers();
        Task<User> login(LoginUser user);
        Task register(User user);
        Task update(int id, User user);
        int validatepasswordStrong(string password);
    }
}