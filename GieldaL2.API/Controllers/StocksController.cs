using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GieldaL2.API.ViewModels.Edit;
using GieldaL2.API.ViewModels.View;
using GieldaL2.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GieldaL2.API.Controllers
{
    /// <summary>
    /// Stocks controller containing endpoints to manage stocks.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StocksController : ControllerBase
    {
		GieldaL2Context context;
		public StocksController(GieldaL2Context context)
		{
			this.context = context;
		}

        /// <summary>
        /// Retrieves a list of all stocks.
        /// </summary>
        /// <returns>List of the all stocks and backend statistics.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<StockViewModel>>> Get()
        {
			return new StatisticsViewModel<IEnumerable<StockViewModel>>()
			{
				//TODO: statistics
				Data = (from s in context.Stocks
						select new StockViewModel()
						{
							Id = s.Id,
							Name = s.Name,
							Abbreviation = s.Abbreviation,
							CurrentPrice = s.CurrentPrice,
							PriceDelta = s.PriceDelta
						}).ToList()
			};
        }

        /// <summary>
        /// Retrieves stock with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested stock.</param>
        /// <returns>Stock with the specified ID and backend statistics if success, otherwise 404 when not found.</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel<StockViewModel>> Get(int id)
		{
			var s = context.Stocks.Find(id);
			return new StatisticsViewModel<StockViewModel>()
			{
				//TODO: statistics
				Data = new StockViewModel()
				{
					Id = s.Id,
					Name = s.Name,
					Abbreviation = s.Abbreviation,
					CurrentPrice = s.CurrentPrice,
					PriceDelta = s.PriceDelta
				}
			};
		}

        /// <summary>
        /// Adds stock passed in the request body.
        /// </summary>
        /// <param name="model">Stock which will be added.</param>
        /// <returns>Backend statistics.</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Post([FromBody] EditStockViewModel model)
        {
			DB.Entities.Stock stock = new DB.Entities.Stock()
			{
				Name = model.Name,
				Abbreviation = model.Abbreviation,
				//CurrentPrice = model.CurrentPrice,
				//PriceDelta = model.PriceDelta
			};

			context.Stocks.Add(stock);
			context.SaveChangesAsync();
            return new StatisticsViewModel()
				{
				//TODO: statistics
			};
        }

        /// <summary>
        /// Edits stock with the specified ID.
        /// </summary>
        /// <param name="id">ID of the stock which will be edited.</param>
        /// <param name="model">New data which will be applied to the stock.</param>
        /// <returns>Backend statistics if stock has been modified with success, otherwise 404 if not found.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<StatisticsViewModel>> Put(int id, [FromBody] EditStockViewModel model)
        {
			DB.Entities.Stock stock = context.Stocks.Find(id);

			if (stock == null) return NotFound();

			stock.Name = model.Name;
			stock.Abbreviation = model.Abbreviation;
			//TODO: stock.CurrentPrice = 
			//TODO: stock.PriceDelta = 

			if (await TryUpdateModelAsync<DB.Entities.Stock>(stock))
			{
				await context.SaveChangesAsync();

				return new StatisticsViewModel()
				{
					//TODO: statistics
				};
			}
			else
			{
				return StatusCode(500);
			}
		}

        /// <summary>
        /// Deletes stock with the specified ID.
        /// </summary>
        /// <param name="id">ID of the stock which will be deleted.</param>
        /// <returns>Backend statistics if stock has been deleted with success, otherwise 404 if not found.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Delete(int id)
        {
			DB.Entities.Stock stock = context.Stocks.Find(id);

			if (stock == null) return NotFound();

			context.Stocks.Remove(stock);
			context.SaveChangesAsync();
			return new StatisticsViewModel()
			{
				//TODO: statistics
			};
		}
    }
}
