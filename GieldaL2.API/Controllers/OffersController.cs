using System.Collections.Generic;
using GieldaL2.API.ViewModels.Edit;
using GieldaL2.API.ViewModels.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GieldaL2.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OffersController : ControllerBase
    {
        [HttpGet("sell")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<SellOfferViewModel>>> GetSell()
        {
            return null;
        }

        [HttpGet("sell/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<SellOfferViewModel>> GetSell(int id)
        {
            return null;
        }

        [HttpPost("sell")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> PostSell([FromBody] EditSellOfferViewModel order)
        {
            return null;
        }

        [HttpDelete("sell/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> DeleteSell(int id)
        {
            return null;
        }

        [HttpGet("buy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<BuyOfferViewModel>>> GetBuy()
        {
            return null;
        }

        [HttpGet("buy/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<BuyOfferViewModel>> GetBuy(int id)
        {
            return null;
        }

        [HttpPost("buy")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> PostBuy([FromBody] EditBuyOfferViewModel order)
        {
            return null;
        }

        [HttpDelete("buy/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> DeleteBuy(int id)
        {
            return null;
        }
    }
}