using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class ShareRepository : IShareRepository
    {
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;

        public ShareRepository(GieldaL2Context context)
        {
            _context = context;            
        }


        public Share GetById(int id)
        {
            return _context.Shares.FirstOrDefault(share => share.Id == id);
        }

        public ICollection<Share> GetAll()
        {
            return _context.Shares.ToList();
        }


        public void Add(Share share)
        {
            _context.Add(share);
            _context.SaveChanges();
        }

        public void Edit(Share share)
        {
            _context.SaveChanges();
        }

        public void Remove(Share share)
        {
            _context.Remove(share);
            _context.SaveChanges();
        }
    }
}
