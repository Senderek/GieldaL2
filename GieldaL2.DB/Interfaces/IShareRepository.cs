using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    public interface IShareRepository : IRepository
    {
        Share GetById(int id);
        ICollection<Share> GetAll();

        void Add(Share share);
        void Edit(Share share);
        void Remove(Share share);
    }
}
