using DTOs;

namespace Services
{
    public interface IUserServices
    {
        Task<List<UserDTO>> getAllUsers();
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> login(LoginUserDTO luserDTO);
        Task Register(RegisterUserDTO RuserDTO);
        Task update(int id, RegisterUserDTO userDTO);
        int validatepasswordStrong(string password);
    }
}