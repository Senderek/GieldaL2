using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly GieldaL2Context _context;
        public TransactionRepository(GieldaL2Context context)
        {
            _context = context;
        }

        public Transaction GetById(int id)
        {
            return _context.Transactions.FirstOrDefault(transaction => transaction.Id == id);
        }

        public ICollection<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public void Add(Transaction transaction)
        {
            _context.Add(transaction);
            _context.SaveChanges();
        }   

        public void Remove(Transaction transaction)
        {
            _context.Remove(transaction);
            _context.SaveChanges();
        }
    }
}
