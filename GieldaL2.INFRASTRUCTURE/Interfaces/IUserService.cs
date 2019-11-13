using System.Collections.Generic;
using GieldaL2.INFRASTRUCTURE.DTO;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    public interface IUserService
    {
        ICollection<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);
        void AddUser(UserDTO user);
        bool EditUser(int id, UserDTO user);
        bool DeleteUser(int id);
    }
}
