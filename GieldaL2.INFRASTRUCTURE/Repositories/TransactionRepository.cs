using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;
        public TransactionRepository(GieldaL2Context context)
        {
            _context = context;
        }

        public Transaction GetById(int id)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Transactions.FirstOrDefault(transaction => transaction.Id == id);
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        public ICollection<Transaction> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Transactions.ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        public void Add(Transaction transaction)
        {
            _context.Add(transaction);

            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }

        public void Remove(Transaction transaction)
        {
            _context.Remove(transaction);

            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
    }
}
