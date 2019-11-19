using GieldaL2.DB.Entities;
using System.Collections.Generic;

namespace GieldaL2.DB.Interfaces
{
    /// <summary>
    /// Interface implemented by StockRpeository class
    /// </summary>
    public interface IStockRepository : IRepository
    {
        /// <summary>
        /// Declaration of method that returns specific Stock entity
        /// </summary>
        /// <param name="id">Identifier of stock</param>
        /// <returns>Singular Stock entity</returns>
        Stock GetById(int id);
        /// <summary>
        /// Declaration of method that returns collection of Stock entities
        /// </summary>
        /// <returns>Collection of stock entities</returns>
        ICollection<Stock> GetAll();

        /// <summary>
        /// Declaration of method for adding stock entity to database
        /// </summary>
        /// <param name="stock">Stock entity to add</param>
        void Add(Stock stock);
        /// <summary>
        /// Declaration of method for modifying stock entity
        /// </summary>
        /// <param name="stock">Stock entity to modify</param>
        void Edit(Stock stock);
        /// <summary>
        /// Declaration of method for removing stock entity
        /// </summary>
        /// <param name="stock">Stock entity to remove</param>
        void Remove(Stock stock);
    }
}
