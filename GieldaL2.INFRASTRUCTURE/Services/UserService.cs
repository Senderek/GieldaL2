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
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<UserDTO> GetAllUsers()
        {
            return _userRepository.GetAll().Select(p => Mapper.Map<UserDTO>(p)).ToList();
        }

        public UserDTO GetUserById(int id)
        {
            return Mapper.Map<UserDTO>(_userRepository.GetById(id.ToString()));
        }

        public void AddUser(UserDTO user)
        {
            _userRepository.Add(Mapper.Map<User>(user));
        }

        public bool EditUser(int id, UserDTO user)
        {
            var userToEdit = _userRepository.GetById(id.ToString());
            if (userToEdit == null)
            {
                return false;
            }

            userToEdit = Mapper.Map<User>(user);
            _userRepository.Edit(userToEdit);

            return true;
        }

        public bool DeleteUser(int id)
        {
            var userToDelete = _userRepository.GetById(id.ToString());
            if (userToDelete == null)
            {
                return false;
            }

            _userRepository.Remove(userToDelete);
            return true;
        }
    }
}
