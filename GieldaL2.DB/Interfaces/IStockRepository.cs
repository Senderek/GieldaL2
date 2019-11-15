using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    public interface IStockRepository : IRepository
    {
        Stock GetById(int id);
        ICollection<Stock> GetAll();

        void Add(Stock stock);
        void Edit(Stock stock);
        void Remove(Stock stock);
    }
}
