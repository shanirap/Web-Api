using Bakery;
using Entities;

namespace Repositories
{
    public interface IUsersData
    {
        Task<User> getUserId(int id);
        Task<List<User>> getUsers();
        Task<User> Login(User loginUser);
        Task Register(User user);
        Task Update(int id, User user);
    }
}