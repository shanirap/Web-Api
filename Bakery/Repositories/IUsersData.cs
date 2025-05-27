using Bakery;
using Entities;

namespace Repositories
{
    public interface IUsersData
    {
        Task<List<User>> getAllUsers();
        Task<User> getUserById(int id);
        Task<User> Login(User loginUser);
        Task Register(User user);
        Task Update(int id, User user);
    }
}