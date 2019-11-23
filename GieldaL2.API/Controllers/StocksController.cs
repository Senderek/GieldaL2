using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GieldaL2.API.ViewModels.Edit;
using GieldaL2.API.ViewModels.View;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using GieldaL2.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GieldaL2.INFRASTRUCTURE.DTO;
using Omu.ValueInjecter;

namespace GieldaL2.API.Controllers
{
    /// <summary>
    /// Stocks controller containing endpoints to manage stocks.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StocksController : ControllerBase
    {
		IStockService service;
		public StocksController(IStockService service)
		{
			this.service = service;
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
			var dto = new StatisticsDTO();
			var data = service.GetAllStocks(dto).Select(p => Mapper.Map<StockViewModel>(p)).ToList();

			var statistics = Mapper.Map<StatisticsViewModel<IEnumerable<StockViewModel>>>(dto);
			statistics.Data = data;

			return statistics;
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
			var dto = new StatisticsDTO();
			var stock = service.GetStockById(id, dto);

			if (stock == null)
			{
				return NotFound(Mapper.Map<StatisticsViewModel>(dto));
			}

			var statistics = Mapper.Map<StatisticsViewModel<StockViewModel>>(dto);
			statistics.Data = Mapper.Map<StockViewModel>(stock);

			return statistics;
		}

        /// <summary>
        /// Adds stock passed in the request body.
        /// </summary>
        /// <param name="model">Stock which will be added.</param>
        /// <returns>Backend statistics.</returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Post([FromBody] EditStockViewModel model)
        {
			var statisticsDto = new StatisticsDTO();
			service.AddStock(Mapper.Map<StockDTO>(model), statisticsDto);

			Response.StatusCode = 201;
			return Mapper.Map<StatisticsViewModel>(statisticsDto);
		}

        /// <summary>
        /// Edits stock with the specified ID.
        /// </summary>
        /// <param name="id">ID of the stock which will be edited.</param>
        /// <param name="model">New data which will be applied to the stock.</param>
        /// <returns>Backend statistics if stock has been modified with success, otherwise 404 if not found.</returns>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Put(int id, [FromBody] EditStockViewModel model)
        {
			var dto = new StatisticsDTO();
			var stock = service.GetStockById(id, dto);

			if (stock == null)
			{
				return NotFound(Mapper.Map<StatisticsViewModel>(dto));
			}

			stock = Mapper.Map<StockDTO>(stock);
			service.EditStock(id, stock, dto);

			return Mapper.Map<StatisticsViewModel>(dto);
		}

        /// <summary>
        /// Deletes stock with the specified ID.
        /// </summary>
        /// <param name="id">ID of the stock which will be deleted.</param>
        /// <returns>Backend statistics if stock has been deleted with success, otherwise 404 if not found.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Delete(int id)
        {
			var dto = new StatisticsDTO();
			if (!service.DeleteStock(id, dto))
			{
				return NotFound(Mapper.Map<StatisticsViewModel>(dto));
			}

			return Mapper.Map<StatisticsViewModel>(dto);
		}
    }
}
