using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    /// <summary>
    /// Class that implements IStockRepository interface
    /// </summary>
    public class StockRepository : IStockRepository
    {
        /// <summary>
        /// Property that stores last  operation time on database
        /// </summary>
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;

        public StockRepository(GieldaL2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that returns specific Stock entity
        /// </summary>
        /// <param name="id">identifier of Stock</param>
        /// <returns>Singular Sotck entity</returns>
        public Stock GetById(int id)
        {
            return _context.Stocks.FirstOrDefault(stock => stock.Id == id);
        }

        /// <summary>
        /// Metohd that returns Collection of Stock entities
        /// </summary>
        /// <returns>Collection of Stock entities</returns>
        public ICollection<Stock> GetAll()
        {
            return _context.Stocks.ToList();
        }

        /// <summary>
        /// Method for adding Stock entity to database
        /// </summary>
        /// <param name="stock">Stock entity to add</param>
        public void Add(Stock stock)
        {
            _context.Add(stock);
            _context.SaveChanges();
        }

        /// <summary>
        /// Method for modifying Stock entity
        /// </summary>
        /// <param name="stock">Stock entity to modify</param>
        public void Edit(Stock stock)
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Method for removing Stck entity from database
        /// </summary>
        /// <param name="stock">Stock entity to remove</param>
        public void Remove(Stock stock)
        {
            _context.Remove(stock);
            _context.SaveChanges();
        }
    }
}
