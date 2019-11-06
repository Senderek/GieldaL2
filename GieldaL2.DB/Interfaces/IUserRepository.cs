using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    public interface IUserRepository : IRepository
    {
        User GetById(string id);
        ICollection<User> GetAll();

        void Add(User user);
        void Edit(User user);
        void Remove(User user);
    }
}
