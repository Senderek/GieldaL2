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