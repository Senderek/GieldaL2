using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

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

        public ICollection<TransactionDTO> GetAll(StatisticsDTO statistics)
        {
            var transaction = _transactionRepository.GetAll().Select(t => Mapper.Map<TransactionDTO>(t)).ToList();
            statistics.SelectsTime += _transactionRepository.LastOperationTime;
            statistics.SelectsCount++;

            return transaction;
        }
    }
}
