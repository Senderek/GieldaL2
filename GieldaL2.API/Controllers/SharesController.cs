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
    /// Shares controller containing endpoints to manage user shares.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SharesController : ControllerBase
    {
		GieldaL2Context context;

		public SharesController(GieldaL2Context context)
		{
			this.context = context;
		}

        /// <summary>
        /// Retrieves a list of all shares.
        /// </summary>
        /// <returns>List of the all shares and backend statistics.</returns>
		[HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel<IEnumerable<ShareViewModel>>> Get()
		{
			return new StatisticsViewModel<IEnumerable<ShareViewModel>>()
			{
				//TODO: statistics
				Data = (from s in context.Shares
						select new ShareViewModel()
						{
							Id = s.Id,
							UserId = 0,//TODO: s.Owner.Id,
							Amount = s.Amount,
							StockId = s.Stock.Id
						}).ToList()
			};
		}

        /// <summary>
        /// Retrieves share with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested share.</param>
        /// <returns>Share with the specified ID and backend statistics if success, otherwise 404 when not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel<ShareViewModel>> Get(int id)
		{
			var s = context.Shares.Find(id);
			return new StatisticsViewModel<ShareViewModel>()
			{
				//TODO: statistics
				Data = new ShareViewModel()
				{
					Id = s.Id,
					UserId = 0,//TODO: s.Owner.Id,
					Amount = s.Amount,
					StockId = s.Stock.Id
				}
			};
		}

        /// <summary>
        /// Adds share offer passed in the request body.
        /// </summary>
        /// <param name="model">Share which will be added.</param>
        /// <returns>Backend statistics.</returns>
		[HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel> Post([FromBody] EditShareViewModel model)
		{
			DB.Entities.User owner = context.Users.Find(model.UserId);
			DB.Entities.Stock stock = context.Stocks.Find(model.StockId);

			if (owner == null || stock == null) return StatusCode(500);

			DB.Entities.Share Share = new DB.Entities.Share()
			{
				Owner = owner,
				Amount = model.Amount,
				Stock = stock
			};

			context.Shares.Add(Share);
			context.SaveChangesAsync();
			return new StatisticsViewModel()
			{
				//TODO: statistics
			};
		}

        /// <summary>
        /// Edits share with the specified ID.
        /// </summary>
        /// <param name="id">ID of the share which will be edited.</param>
        /// <param name="model">New data which will be applied to the share.</param>
        /// <returns>Backend statistics if share has been modified with success, otherwise 404 if not found.</returns>
		[HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
		public async Task<ActionResult<StatisticsViewModel>> Put(int id, [FromBody] EditShareViewModel model)
		{
			DB.Entities.Share shares = context.Shares.Find(id);

			if (shares == null) return NotFound();

			shares.Amount = model.Amount;

			DB.Entities.User owner = context.Users.Find(model.UserId);
			DB.Entities.Stock stock = context.Stocks.Find(model.StockId);

			if (owner == null || stock == null) return NotFound();

			shares.Owner = owner;
			shares.Stock = stock;


			if (await TryUpdateModelAsync<DB.Entities.Share>(shares))
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
        /// Deletes share with the specified ID.
        /// </summary>
        /// <param name="id">ID of the share which will be deleted.</param>
        /// <returns>Backend statistics if share has been deleted with success, otherwise 404 if not found.</returns>
		[HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel> Delete(int id)
		{
			DB.Entities.Share shares = context.Shares.Find(id);

			if (shares == null) return NotFound();

			context.Shares.Remove(shares);
			context.SaveChangesAsync();
			return new StatisticsViewModel()
			{
				//TODO: statistics
			};
		}
	}
}