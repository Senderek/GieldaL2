using System.Collections.Generic;
using GieldaL2.INFRASTRUCTURE.DTO;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    public interface IUserService
    {
        ICollection<UserDTO> GetAllUsers(StatisticsDTO statistics);
        UserDTO GetUserById(int id, StatisticsDTO statistics);
        void AddUser(UserDTO user, StatisticsDTO statistics);
        bool EditUser(int id, UserDTO user, StatisticsDTO statistics);
        bool DeleteUser(int id, StatisticsDTO statistics);
    }
}
