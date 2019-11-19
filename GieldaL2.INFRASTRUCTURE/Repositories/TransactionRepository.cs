using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    /// <summary>
    /// Class that implements ITransactionRepository interface
    /// </summary>
    public class TransactionRepository : ITransactionRepository
    {
        /// <summary>
        /// Property that stores last  operation time on database
        /// </summary>
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;
        public TransactionRepository(GieldaL2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that returns specific transaction entity
        /// </summary>
        /// <param name="id">identifier of Transation</param>
        /// <returns>Singular transaction entity</returns>
        public Transaction GetById(int id)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Transactions.FirstOrDefault(transaction => transaction.Id == id);
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        /// <summary>
        /// Method that returns Collection of transaction entities
        /// </summary>
        /// <returns>Collection of transaction entities</returns>
        public ICollection<Transaction> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var data = _context.Transactions.ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;

            return data;
        }

        /// <summary>
        /// Metohod for adding transaction entity to daatabase
        /// </summary>
        /// <param name="transaction">Transaction entity to add</param>
        public void Add(Transaction transaction)
        {
            _context.Add(transaction);

            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Method for removing transaciton entity from database
        /// </summary>
        /// <param name="transaction">transaction entity to remove</param>
        public void Remove(Transaction transaction)
        {
            _context.Remove(transaction);

            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
    }
}
