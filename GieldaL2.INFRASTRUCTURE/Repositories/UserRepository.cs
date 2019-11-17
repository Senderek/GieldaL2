using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class UserRepository : IUserRepository
    {
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;
        public UserRepository(GieldaL2Context context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Users.FirstOrDefault(user => user.Id == id);
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Users.FirstOrDefault(user => user.UserName == userName && user.Password == password);
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        public ICollection<User> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Users.ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        public void Add(User user)
        {
            _context.Add(user);

            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }

        public void Edit(User user)
        {
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }  

        public void Remove(User user)
        {
            _context.Remove(user);

            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
    }
}
