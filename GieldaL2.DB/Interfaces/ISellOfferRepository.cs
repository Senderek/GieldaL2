using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    public interface ISellOfferRepository : IRepository
    {
        SellOffer GetById(int id);
        ICollection<SellOffer> GetAll();

        void Add(SellOffer sellOffer);
        void Remove(SellOffer sellOffer);
    }
}
