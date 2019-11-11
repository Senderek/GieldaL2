using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    public interface ITransactionRepository : IRepository
    {
        Transaction GetById(int id);
        ICollection<Transaction> GetAll();

        void Add(Transaction transaction);
        void Remove(Transaction transaction);
    }
}
