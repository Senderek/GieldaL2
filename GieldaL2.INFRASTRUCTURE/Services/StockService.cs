using System.Collections.Generic;
using System.Linq;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Omu.ValueInjecter;

namespace GieldaL2.INFRASTRUCTURE.Services
{
	public class StockService : IStockService
	{
		private readonly IStockRepository repo;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserService"/> class.
		/// </summary>
		/// <param name="userRepository">Repository containing users.</param>
		public StockService(IStockRepository repository)
		{
			this.repo = repository;
		}

		public void AddStock(StockDTO stock, StatisticsDTO statistics)
		{
			repo.Add(Mapper.Map<Stock>(stock));
			statistics.InsertsTime += repo.LastOperationTime;
			statistics.InsertsCount++;
		}

		public bool DeleteStock(int id, StatisticsDTO statistics)
		{
			var stock = repo.GetById(id);
			statistics.SelectsTime += repo.LastOperationTime;
			statistics.SelectsCount++;

			if (stock == null)
			{
				return false;
			}

			repo.Remove(stock);
			statistics.DeletesTime += repo.LastOperationTime;
			statistics.DeletesCount++;

			return true;
		}

		public bool EditStock(int id, StockDTO stock, StatisticsDTO statistics)
		{
			var edited = repo.GetById(id);
			statistics.SelectsTime += repo.LastOperationTime;
			statistics.SelectsCount++;

			if (edited == null)
			{
				return false;
			}

			edited.Name = stock.Name;
			edited.Abbreviation = stock.Abbreviation;
			edited.CurrentPrice = stock.CurrentPrice;
			edited.PriceDelta = stock.PriceDelta;

			repo.Edit(edited);
			statistics.UpdatesTime += repo.LastOperationTime;
			statistics.UpdatesCount++;

			return true;
		}

		public ICollection<StockDTO> GetAllStocks(StatisticsDTO statistics)
		{
			var stocks = repo.GetAll().Select(p => Mapper.Map<StockDTO>(p)).ToList();
			statistics.SelectsTime += repo.LastOperationTime;
			statistics.SelectsCount++;

			return stocks;
		}

		public StockDTO GetStockById(int id, StatisticsDTO statistics)
		{
			var stock = repo.GetById(id);
			statistics.SelectsTime += repo.LastOperationTime;
			statistics.SelectsCount++;

			if (stock == null)
			{
				return null;
			}

			return Mapper.Map<StockDTO>(stock);
		}
	}
}
