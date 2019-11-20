using GieldaL2.INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    public interface IBuyOfferService : IService
    {
        BuyOfferDTO GetById(int id, StatisticsDTO statistics);
        ICollection<BuyOfferDTO> GetAll(StatisticsDTO statistics);
        void Add(BuyOfferDTO sellOffer, StatisticsDTO statistics);
        bool Delete(int id, StatisticsDTO statistics);
    }
}
