using GieldaL2.INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    public interface ISellOfferService : IService
    {
        SellOfferDTO GetById(int id, StatisticsDTO statistics);
        ICollection<BuyOfferDTO> GetByUserId(int userId, StatisticsDTO statistics);
        ICollection<SellOfferDTO> GetAll(StatisticsDTO statistics);
        void Add(SellOfferDTO sellOffer, StatisticsDTO statistics);
        bool Delete(int id, StatisticsDTO statistics);
    }
}
