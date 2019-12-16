using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Services
{
    /// <summary>
    /// Class that implements ITransactionService interface
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        /// <summary>
        /// Method that returns specific Transaction DTO
        /// </summary>
        /// <param name="id">Identifier of transaction</param>
        /// <param name="statistics">Statistics DTO</param>
        /// <returns>Singular Transaction DTO</returns>
        public TransactionDTO GetById(int id, StatisticsDTO statistics)
        {
            var transaction = _transactionRepository.GetById(id);
            statistics.SelectsTime += _transactionRepository.LastOperationTime;
            statistics.SelectsCount++;

            if(transaction == null)
            {
                return null;
            }

            return Mapper.Map<TransactionDTO>(transaction);
        }

        /// <summary>
        /// Method that returns Collection of Transaction DTOs
        /// </summary>
        /// <param name="statistics">Statistics DTO</param>
        /// <returns>Collection of Transaction DTOs</returns>
        public ICollection<TransactionDTO> GetAll(StatisticsDTO statistics)
        {
            var transaction = _transactionRepository.GetAll().Select(t => Mapper.Map<TransactionDTO>(t)).ToList();
            statistics.SelectsTime += _transactionRepository.LastOperationTime;
            statistics.SelectsCount++;

            return transaction;
        }

        public void Add(TransactionDTO transactionDTO, StatisticsDTO statisticsDTO)
        {
            _transactionRepository.Add(Mapper.Map<Transaction>(transactionDTO));
            statisticsDTO.SelectsTime += _transactionRepository.LastOperationTime;
            statisticsDTO.SelectsCount++;
        }

    }
}
