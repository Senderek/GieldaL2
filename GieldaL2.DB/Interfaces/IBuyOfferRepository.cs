using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    public interface IBuyOfferRepository : IRepository
    {
        BuyOffer GetById(int id);
        ICollection<BuyOffer> GetAll();

        void Add(BuyOffer buyOffer);
        void Remove(BuyOffer buyOffer);
    }
}
