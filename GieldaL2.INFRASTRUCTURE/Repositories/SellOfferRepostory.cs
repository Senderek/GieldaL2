using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System.Collections.Generic;
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
            return _context.SellOffers.FirstOrDefault(selloffer => selloffer.Id == id);
        }

        /// <summary>
        /// Mehod that returns Collection of SellOffer entities
        /// </summary>
        /// <returns>Collection of SellOffer entities</returns>
        public ICollection<SellOffer> GetAll()
        {
            return _context.SellOffers.ToList();
        }

        /// <summary>
        /// Method for adding SellOffer entity to database 
        /// </summary>
        /// <param name="sellOffer">SellOffer entity to add</param>
        public void Add(SellOffer sellOffer)
        {
            _context.SellOffers.Add(sellOffer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Method for removing SellOffer entity from database
        /// </summary>
        /// <param name="sellOffer">SellOffer entity to remove</param>
        public void Remove(SellOffer sellOffer)
        {
            _context.Remove(sellOffer);
            _context.SaveChanges();
        }
    }
}
