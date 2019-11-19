using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class SellOfferRepostory : ISellOfferRepository
    {
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;

        public SellOfferRepostory(GieldaL2Context context)
        {
            _context = context;
        }


        public SellOffer GetById(int id)
        {
            return _context.SellOffers.FirstOrDefault(selloffer => selloffer.Id == id);
        }

        public ICollection<SellOffer> GetAll()
        {
            return _context.SellOffers.ToList();
        }


        public void Add(SellOffer sellOffer)
        {
            _context.SellOffers.Add(sellOffer);
            _context.SaveChanges();
        }

        public void Remove(SellOffer sellOffer)
        {
            _context.Remove(sellOffer);
            _context.SaveChanges();
        }
    }
}
