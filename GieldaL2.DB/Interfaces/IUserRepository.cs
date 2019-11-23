using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    /// <summary>
    /// Interface implemented by UserRepository class
    /// </summary>
    public interface IUserRepository : IRepository
    {
        /// <summary>
        /// Declaration of method that returns User entity
        /// </summary>
        /// <param name="id">Identifier of User</param>
        /// <returns>Singular user entity</returns>
        User GetById(int id);
        /// <summary>
        /// Declaration of method that returns User entity
        /// </summary>
        /// <param name="userName">Username of User</param>
        /// <param name="password">Password of User</param>
        /// <returns>Singular user entity</returns>
        User GetByUserNameAndPassword(string userName, string password);

        /// <summary>
        /// Retrieves an user with the specified name.
        /// </summary>
        /// <param name="name">Name of the requested user.</param>
        /// <returns>User entity if found, otherwise null.</returns>
        User GetByName(string name);

        /// <summary>
        /// Declaration of method that returns Collection of user entities
        /// </summary>
        /// <returns>Collection of User entities</returns>
        ICollection<User> GetAll();

        /// <summary>
        /// Declaration of method for adding User to database
        /// </summary>
        /// <param name="user">User entity to add</param>
        void Add(User user);
        /// <summary>
        /// Declaration of method for modifying User
        /// </summary>
        /// <param name="user">User entity to modify</param>
        void Edit(User user);
        /// <summary>
        /// Declaration of method for removing user
        /// </summary>
        /// <param name="user">User entity to remove</param>
        void Remove(User user);
    }
}
