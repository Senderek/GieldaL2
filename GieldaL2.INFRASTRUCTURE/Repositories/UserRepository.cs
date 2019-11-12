using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GieldaL2Context _context;
        public UserRepository(GieldaL2Context context)
        {
            _context = context;
        }

        public User GetById(string id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Edit(User user)
        {
            _context.SaveChanges();
        }  

        public void Remove(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
