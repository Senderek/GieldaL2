using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class StockRepository : IStockRepository
    {
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;

        public StockRepository(GieldaL2Context context)
        {
            _context = context;
        }

        public Stock GetById(int id)
        {
            return _context.Stocks.FirstOrDefault(stock => stock.Id == id);
        }

        public ICollection<Stock> GetAll()
        {
            return _context.Stocks.ToList();
        }

        public void Add(Stock stock)
        {
            _context.Add(stock);
            _context.SaveChanges();
        }

        public void Edit(Stock stock)
        {
            _context.SaveChanges();
        }

        public void Remove(Stock stock)
        {
            _context.Remove(stock);
            _context.SaveChanges();
        }
    }
}
