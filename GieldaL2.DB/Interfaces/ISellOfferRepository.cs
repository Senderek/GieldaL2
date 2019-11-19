using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    /// <summary>
    /// Interface implemented by SellOfferRepository class
    /// </summary>
    public interface ISellOfferRepository : IRepository
    {
        /// <summary>
        /// Declaration of method that returns specific SellOffer entity
        /// </summary>
        /// <param name="id">Identifier of offer to sell</param>
        /// <returns>Singular SellOffer entity</returns>
        SellOffer GetById(int id);
        /// <summary>
        /// Declaration of method that returns Collection of SellOffer entities
        /// </summary>
        /// <returns>Collection of SellOffer entities</returns>
        ICollection<SellOffer> GetAll();

        /// <summary>
        /// Declaration of method for adding SellOffer to database
        /// </summary>
        /// <param name="sellOffer">SellOffer entity to add</param>
        void Add(SellOffer sellOffer);
        /// <summary>
        /// Declaration of method for removing SellOffer from database
        /// </summary>
        /// <param name="sellOffer">SellOffer entity to remove</param>
        void Remove(SellOffer sellOffer);
    }
}
