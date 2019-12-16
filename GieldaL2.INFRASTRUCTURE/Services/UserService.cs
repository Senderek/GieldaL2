using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Omu.ValueInjecter;

namespace GieldaL2.INFRASTRUCTURE.Services
{
    /// <summary>
    /// Service containing methods to manage users
    /// </summary>
    public class UserService : IService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">Repository containing users.</param>
        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>Collection of retrieved users from the database.</returns>
        public ICollection<UserDTO> GetAllUsers(StatisticsDTO statistics)
        {
            var users = _userRepository.GetAll().Select(p => Mapper.Map<UserDTO>(p)).ToList();
            statistics.SelectsTime += _userRepository.LastOperationTime;
            statistics.SelectsCount++;

            return users;
        }

        /// <summary>
        /// Retrieves an user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested user.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>User DTO if found, otherwise null.</returns>
        public UserDTO GetUserById(int id, StatisticsDTO statistics)
        {
            var user = _userRepository.GetById(id);
            statistics.SelectsTime += _userRepository.LastOperationTime;
            statistics.SelectsCount++;

            if (user == null)
            {
                return null;
            }

            return Mapper.Map<UserDTO>(user);
        }

        /// <summary>
        /// Retrieves an user with the specified name.
        /// </summary>
        /// <param name="name">Name of the requested user.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>User DTO if found, otherwise null.</returns>
        public UserDTO GetUserByName(string name, StatisticsDTO statistics)
        {
            var user = _userRepository.GetByName(name);
            statistics.SelectsTime += _userRepository.LastOperationTime;
            statistics.SelectsCount++;

            if (user == null)
            {
                return null;
            }

            return Mapper.Map<UserDTO>(user);
        }

        /// <summary>
        /// Adds user passed in the parameter to the database.
        /// </summary>
        /// <param name="user">User DTO which will be added to the database.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        public void AddUser(UserDTO user, StatisticsDTO statistics)
        {
            var mappedUser = Mapper.Map<User>(user);
            mappedUser.Password = _authService.HashPassword(user.Password);

            _userRepository.Add(Mapper.Map<User>(mappedUser));
            statistics.InsertsTime += _userRepository.LastOperationTime;
            statistics.InsertsCount++;
        }

        /// <summary>
        /// Edits user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the user which will be edited.</param>
        /// <param name="user">User data which will be applied.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>True if user with the specified ID has been found and edited, otherwise false.</returns>
        public bool EditUser(int id, UserDTO user, StatisticsDTO statistics)
        {
            var userToEdit = _userRepository.GetById(id);
            statistics.SelectsTime += _userRepository.LastOperationTime;
            statistics.SelectsCount++;

            if (userToEdit == null)
            {
                return false;
            }

            userToEdit.UserName = user.Login;
            userToEdit.Name = user.Name;
            userToEdit.Surname = user.Surname;
            userToEdit.EMail = user.EMail;

            if (user.Password != null)
            {
                userToEdit.Password = _authService.HashPassword(user.Password);
            }

            userToEdit.Money = user.Value;

            _userRepository.Edit(userToEdit);
            statistics.UpdatesTime += _userRepository.LastOperationTime;
            statistics.UpdatesCount++;

            return true;
        }

        /// <summary>
        /// Deletes user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the user which will be deleted.</param>
        /// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
        /// <returns>True if user with the specified ID has been found and deleted, otherwise false.</returns>
        public bool DeleteUser(int id, StatisticsDTO statistics)
        {
            var userToDelete = _userRepository.GetById(id);
            statistics.SelectsTime += _userRepository.LastOperationTime;
            statistics.SelectsCount++;

            if (userToDelete == null)
            {
                return false;
            }

            _userRepository.Remove(userToDelete);
            statistics.DeletesTime += _userRepository.LastOperationTime;
            statistics.DeletesCount++;

            return true;
        }
    }
}
