using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using GieldaL2.INFRASTRUCTURE.Repositories;
using Omu.ValueInjecter;

namespace GieldaL2.INFRASTRUCTURE.Services
{
    public class UserService : IService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<UserDTO> GetAllUsers(StatisticsDTO statistics)
        {
            var users = _userRepository.GetAll().Select(p => Mapper.Map<UserDTO>(p)).ToList();
            statistics.SelectsTime += _userRepository.LastOperationTime;
            statistics.SelectsCount++;

            return users;
        }

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

        public void AddUser(UserDTO user, StatisticsDTO statistics)
        {
            _userRepository.Add(Mapper.Map<User>(user));
            statistics.InsertsTime += _userRepository.LastOperationTime;
            statistics.InsertsCount++;
        }

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
            userToEdit.Password = user.Password;
            userToEdit.Money = user.Value;

            _userRepository.Edit(userToEdit);
            statistics.UpdatesTime += _userRepository.LastOperationTime;
            statistics.UpdatesCount++;

            return true;
        }

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
