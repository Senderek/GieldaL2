using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    /// <summary>
    /// Interface implemented by BuyOfferRepository class
    /// </summary>
    public interface IBuyOfferRepository : IRepository
    {
        /// <summary>
        /// Declaration of method that returns specific BuyOffer entity
        /// </summary>
        /// <param name="id">Identifier of offer to buy</param>
        /// <returns>Singular BuyOffer entity</returns>
        BuyOffer GetById(int id);

        /// <summary>
        /// Declaration of method that returns Collection of BuyOffer entities for the specified user
        /// </summary>
        /// <returns>Collection of BuyOffers</returns>
        ICollection<BuyOffer> GetByUserId(int userId);

        /// <summary>
        /// Declaration of method that returns Collection of BuyOffer entities
        /// </summary>
        /// <returns>Collection of BuyOffers</returns>
        ICollection<BuyOffer> GetAll();

        /// <summary>
        /// Declaration of method for adding offer to database
        /// </summary>
        /// <param name="buyOffer">BuyOffer entity to add</param>
        void Add(BuyOffer buyOffer);
        /// <summary>
        /// Declaration of method for removing offer from database
        /// </summary>
        /// <param name="buyOffer">BuyOffer entity to remove</param>
        void Remove(BuyOffer buyOffer);
    }
}
