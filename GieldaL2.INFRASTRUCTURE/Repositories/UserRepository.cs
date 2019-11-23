using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    /// <summary>
    /// Repository containing users data.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Time of the last database operation (it was easier to do it this way instead of creating "out int time" in the every
        /// method because out variables cannot be assigned to the class members which is done in the services).
        /// </summary>
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">Entity Framework context.</param>
        public UserRepository(GieldaL2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves an user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested user.</param>
        /// <returns>User entity if found, otherwise null.</returns>
        public User GetById(int id)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Users.FirstOrDefault(user => user.Id == id);
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        /// <summary>
        /// Retrieves an user with the specified name.
        /// </summary>
        /// <param name="name">Name of the requested user.</param>
        /// <returns>User entity if found, otherwise null.</returns>
        public User GetByName(string name)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Users.FirstOrDefault(user => user.UserName == name);
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        /// <summary>
        /// Retrieves an user with the specified username and password.
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>User entity if found, otherwise null.</returns>
        public User GetByUserNameAndPassword(string userName, string password)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Users.FirstOrDefault(user => user.UserName == userName && user.Password == password);
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        /// <summary>
        /// Retrieves all user entities from the Users table.
        /// </summary>
        /// <returns>List of the user entities.</returns>
        public ICollection<User> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Users.ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        /// <summary>
        /// Adds user entity to the Users table.
        /// </summary>
        /// <param name="user">User entity which will be added to the database.</param>
        public void Add(User user)
        {
            _context.Add(user);

            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Applies changes done in the user entity in the database.
        /// </summary>
        /// <param name="user">User entity which has been modified.</param>
        public void Edit(User user)
        {
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }  

        /// <summary>
        /// Removes user entity from the Users table.
        /// </summary>
        /// <param name="user">User entity which will be removed.</param>
        public void Remove(User user)
        {
            _context.Remove(user);

            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
    }
}
