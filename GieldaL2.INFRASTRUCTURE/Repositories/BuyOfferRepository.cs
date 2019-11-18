using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class BuyOfferRepository : IBuyOfferRepository
    {
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;

        public BuyOfferRepository(GieldaL2Context context)
        {
            _context = context;
        }

        public BuyOffer GetById(int id)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.BuyOffers.FirstOrDefault(offer => offer.Id == id);
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return data;
        }

        public ICollection<BuyOffer> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var data = _context.BuyOffers.ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return data;
        }


        public void Add(BuyOffer buyOffer)
        {
            _context.Add(buyOffer);
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
       
        public void Remove(BuyOffer buyOffer)
        {
            _context.Remove(buyOffer);
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
    }
}
