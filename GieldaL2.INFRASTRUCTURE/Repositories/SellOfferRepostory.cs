using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    /// <summary>
    /// Class that implements ISellRepository interface
    /// </summary>
    public class SellOfferRepostory : ISellOfferRepository
    {
        /// <summary>
        /// Property that stores last operation time on database
        /// </summary>
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;

        public SellOfferRepostory(GieldaL2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that returns specific SelOffer entity
        /// </summary>
        /// <param name="id">Identifier of SellOffer</param>
        /// <returns>Singular SellOffer entity</returns>
        public SellOffer GetById(int id)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.SellOffers.FirstOrDefault(selloffer => selloffer.Id == id);
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return data;
        }

        /// <summary>
        /// Mehod that returns Collection of SellOffer entities
        /// </summary>
        /// <returns>Collection of SellOffer entities</returns>
        public ICollection<SellOffer> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var data = _context.SellOffers.ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return data;
        }

        /// <summary>
        /// Method for adding SellOffer entity to database 
        /// </summary>
        /// <param name="sellOffer">SellOffer entity to add</param>
        public void Add(SellOffer sellOffer)
        {
            _context.Add(sellOffer);
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;

        }

        /// <summary>
        /// Method for removing SellOffer entity from database
        /// </summary>
        /// <param name="sellOffer">SellOffer entity to remove</param>
        public void Remove(SellOffer sellOffer)
        {
            _context.Remove(sellOffer);
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
    }
}
