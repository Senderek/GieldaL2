using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    /// <summary>
    /// Interface for the repository containing users data.
    /// </summary>
    public interface IUserRepository : IRepository
    {
        /// <summary>
        /// Retrieves an user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested user.</param>
        /// <returns>User entity if found, otherwise null.</returns>
        User GetById(int id);
        
        /// <summary>
        /// Retrieves an user with the specified username and password.
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>User entity if found, otherwise null.</returns>
        User GetByUserNameAndPassword(string userName, string password);
        
        /// <summary>
        /// Retrieves all user entities from the Users table.
        /// </summary>
        /// <returns>List of the user entities.</returns>
        ICollection<User> GetAll();

        /// <summary>
        /// Adds user entity to the Users table.
        /// </summary>
        /// <param name="user">User entity which will be added to the database.</param>
        void Add(User user);

        /// <summary>
        /// Applies changes done in the user entity in the database.
        /// </summary>
        /// <param name="user">User entity which has been modified.</param>
        void Edit(User user);

        /// <summary>
        /// Removes user entity from the Users table.
        /// </summary>
        /// <param name="user">User entity which will be removed.</param>
        void Remove(User user);
    }
}
