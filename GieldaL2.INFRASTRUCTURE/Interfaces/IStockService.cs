using System;
using System.Collections.Generic;
using System.Text;
using GieldaL2.INFRASTRUCTURE.DTO;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
	public interface IStockService : IService
	{
		/// <summary>
		/// Retrieves all stocks from the database.
		/// </summary>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		/// <returns>Collection of retrieved stocks from the database.</returns>
		ICollection<StockDTO> GetAllStocks(StatisticsDTO statistics);

		/// <summary>
		/// Retrieves an stock with the specified ID.
		/// </summary>
		/// <param name="id">ID of the requested stock.</param>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		/// <returns>Stock DTO if found, otherwise null.</returns>
		StockDTO GetStockById(int id, StatisticsDTO statistics);

		/// <summary>
		/// Adds stock passed in the parameter to the database.
		/// </summary>
		/// <param name="stock">Stock DTO which will be added to the database.</param>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		void AddStock(StockDTO stock, StatisticsDTO statistics);

		/// <summary>
		/// Edits stock with the specified ID.
		/// </summary>
		/// <param name="id">ID of the stock which will be edited.</param>
		/// <param name="stock">Stock data which will be applied.</param>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		/// <returns>True if stock with the specified ID has been found and edited, otherwise false.</returns>
		bool EditStock(int id, StockDTO stock, StatisticsDTO statistics);

		/// <summary>
		/// Deletes stock with the specified ID.
		/// </summary>
		/// <param name="id">ID of the stock which will be deleted.</param>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		/// <returns>True if stock with the specified ID has been found and deleted, otherwise false.</returns>
		bool DeleteStock(int id, StatisticsDTO statistics);
	}
}
