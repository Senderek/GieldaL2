using GieldaL2.INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    public interface ITransactionService : IService
    {
        TransactionDTO GetById(int id, StatisticsDTO statistics);
        ICollection<TransactionDTO> GetAll(StatisticsDTO statistics);
    }
}
