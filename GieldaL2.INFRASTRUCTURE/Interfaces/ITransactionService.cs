using GieldaL2.INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    /// <summary>
    /// Interface implemented by TransactionService class
    /// </summary>
    public interface ITransactionService : IService
    {
        /// <summary>
        /// Declaration of method that returns specific Transaction DTO
        /// </summary>
        /// <param name="id">Identifier of Transaction</param>
        /// <param name="statistics">Statistics DTO</param>
        /// <returns>Singular Transaction DTO</returns>
        TransactionDTO GetById(int id, StatisticsDTO statistics);
        /// <summary>
        /// Declaration of method that returns Collection of Transaction DTOs
        /// </summary>
        /// <param name="statistics">Statistics DTO</param>
        /// <returns>Collection of transaction DTOs</returns>
        ICollection<TransactionDTO> GetAll(StatisticsDTO statistics);
    }
}
