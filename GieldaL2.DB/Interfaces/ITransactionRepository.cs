using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    /// <summary>
    /// Interface implemented by TransactionRepository class
    /// </summary>
    public interface ITransactionRepository : IRepository
    {
        /// <summary>
        /// Declaration of method that returns specific Transaction entity
        /// </summary>
        /// <param name="id">identifier of transaction</param>
        /// <returns>Singular transaction entity</returns>
        Transaction GetById(int id);
        /// <summary>
        /// Declaration of method that returns Collection of transaction entities
        /// </summary>
        /// <returns>Collection of transactions</returns>
        ICollection<Transaction> GetAll();

        /// <summary>
        /// Delcaration of method for adding Transaction to database
        /// </summary>
        /// <param name="transaction">Transaction entity to add</param>
        void Add(Transaction transaction);
        /// <summary>
        /// Declaration of method for rmoving transaction from database
        /// </summary>
        /// <param name="transaction">transaction entity to remove</param>
        void Remove(Transaction transaction);
    }
}
