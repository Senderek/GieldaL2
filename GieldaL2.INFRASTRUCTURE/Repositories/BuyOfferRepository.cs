using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    /// <summary>
    /// Class that implements IBuyOfferRepository interface
    /// </summary>
    public class BuyOfferRepository : IBuyOfferRepository
    {
        /// <summary>
        /// Property that stores last  operation time on database
        /// </summary>
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;

        public BuyOfferRepository(GieldaL2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that returns specific BuyOffer entity
        /// </summary>
        /// <param name="id">Identifier of BuyOffer entity</param>
        /// <returns>Singular BuyOffer entity</returns>
        public BuyOffer GetById(int id)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.BuyOffers.FirstOrDefault(offer => offer.Id == id);
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return data;
        }

        /// <summary>
        /// Method that returns Collection of BuyOffer entities for the specified user
        /// </summary>
        /// <returns>Collection of BuyOffer entities</returns>
        public ICollection<BuyOffer> GetByUserId(int userId)
        {
            var watch = Stopwatch.StartNew();
            var data = _context.BuyOffers.Where(p => p.BuyerId == userId).ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return data;
        }

        /// <summary>
        /// Method that returns Collection of BuyOffer entities
        /// </summary>
        /// <returns>Collection of BuyOffer entities</returns>
        public ICollection<BuyOffer> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var data = _context.BuyOffers.ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return data;
        }

        /// <summary>
        /// Method for adding BuyOffer entity to database
        /// </summary>
        /// <param name="buyOffer">BuyOffer entity to add</param>
        public void Add(BuyOffer buyOffer)
        {
            _context.Add(buyOffer);
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
       
        /// <summary>
        /// Method for removing BuyOffer entity from database
        /// </summary>
        /// <param name="buyOffer">BuyOffer entity to remove</param>
        public void Remove(BuyOffer buyOffer)
        {
            _context.Remove(buyOffer);
            var watch = Stopwatch.StartNew();
            _context.SaveChanges();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
        }
    }
}
