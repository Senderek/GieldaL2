using System.Collections.Generic;
using GieldaL2.INFRASTRUCTURE.DTO;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    /// <summary>
    /// Interface for the service containing methods to manage users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>Collection of retrieved users from the database.</returns>
        ICollection<UserDTO> GetAllUsers(StatisticsDTO statistics);

        /// <summary>
        /// Retrieves an user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested user.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>User DTO if found, otherwise null.</returns>
        UserDTO GetUserById(int id, StatisticsDTO statistics);

        /// <summary>
        /// Retrieves an user with the specified name.
        /// </summary>
        /// <param name="name">Name of the requested user.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>User DTO if found, otherwise null.</returns>
        UserDTO GetUserByName(string name, StatisticsDTO statistics);

        /// <summary>
        /// Adds user passed in the parameter to the database.
        /// </summary>
        /// <param name="user">User DTO which will be added to the database.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        void AddUser(UserDTO user, StatisticsDTO statistics);

        /// <summary>
        /// Edits user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the user which will be edited.</param>
        /// <param name="user">User data which will be applied.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>True if user with the specified ID has been found and edited, otherwise false.</returns>
        bool EditUser(int id, UserDTO user, StatisticsDTO statistics);

        /// <summary>
        /// Deletes user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the user which will be deleted.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>True if user with the specified ID has been found and deleted, otherwise false.</returns>
        bool DeleteUser(int id, StatisticsDTO statistics);
    }
}
