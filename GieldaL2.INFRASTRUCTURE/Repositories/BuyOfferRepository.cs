using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class BuyOfferRepository : IBuyOfferRepository
    {
        private readonly GieldaL2Context _context;

        public BuyOfferRepository(GieldaL2Context context)
        {
            _context = context;
        }

        public BuyOffer GetById(int id)
        {
            return _context.BuyOffers.FirstOrDefault(offer => offer.Id == id);
        }

        public ICollection<BuyOffer> GetAll()
        {
            return _context.BuyOffers.ToList();
        }


        public void Add(BuyOffer buyOffer)
        {
            _context.BuyOffers.Add(buyOffer);
            _context.SaveChanges();
        }
       
        public void Remove(BuyOffer buyOffer)
        {
            _context.Remove(buyOffer);
            _context.SaveChanges();
        }
    }
}
