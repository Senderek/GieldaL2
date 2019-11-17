using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var watch = Stopwatch.StartNew();
            var data = _context.SellOffers.FirstOrDefault(selloffer => selloffer.Id == id);
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return data;
        }

        public ICollection<SellOffer> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var data = _context.SellOffers.ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return data;
        }


        public void Add(SellOffer sellOffer)
        {
            _context.Add(sellOffer);
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;

        }

        public void Remove(SellOffer sellOffer)
        {
            _context.Remove(sellOffer);
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
    }
}
