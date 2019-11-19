using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System.Collections.Generic;
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
            return _context.BuyOffers.FirstOrDefault(offer => offer.Id == id);
        }

        /// <summary>
        /// Method that returns Collection of BuyOffer entities
        /// </summary>
        /// <returns>Collection of BuyOffer entities</returns>
        public ICollection<BuyOffer> GetAll()
        {
            return _context.BuyOffers.ToList();
        }

        /// <summary>
        /// Method for adding BuyOffer entity to database
        /// </summary>
        /// <param name="buyOffer">BuyOffer entity to add</param>
        public void Add(BuyOffer buyOffer)
        {
            _context.BuyOffers.Add(buyOffer);
            _context.SaveChanges();
        }
       
        /// <summary>
        /// Method for removing BuyOffer entity from database
        /// </summary>
        /// <param name="buyOffer">BuyOffer entity to remove</param>
        public void Remove(BuyOffer buyOffer)
        {
            _context.Remove(buyOffer);
            _context.SaveChanges();
        }
    }
}
