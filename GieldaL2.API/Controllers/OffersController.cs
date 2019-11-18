using System.Collections.Generic;
using GieldaL2.API.ViewModels.Edit;
using GieldaL2.API.ViewModels.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GieldaL2.API.Controllers
{
    /// <summary>
    /// Offers controller containing endpoints to manage offers.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OffersController : ControllerBase
    {
        /// <summary>
        /// Retrieves list of the all sell offers.
        /// </summary>
        /// <returns>List of the all sell offers and backend statistics.</returns>
        [HttpGet("sell")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<SellOfferViewModel>>> GetSell()
        {
            return null;
        }

        /// <summary>
        /// Retrieves sell offer with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested sell offer.</param>
        /// <returns>Sell offer with the specified ID and backend statistics if success, otherwise 404 when not found.</returns>
        [HttpGet("sell/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<SellOfferViewModel>> GetSell(int id)
        {
            return null;
        }

        /// <summary>
        /// Adds sell offer passed in the request body.
        /// </summary>
        /// <param name="order">Sell offer which will be added.</param>
        /// <returns>Backend statistics.</returns>
        [HttpPost("sell")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> PostSell([FromBody] EditSellOfferViewModel order)
        {
            return null;
        }

        /// <summary>
        /// Deletes sell offer with the specified ID.
        /// </summary>
        /// <param name="id">ID of the sell offer which will be deleted.</param>
        /// <returns>Backend statistics if success, otherwise 404 when ID was not found.</returns>
        [HttpDelete("sell/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> DeleteSell(int id)
        {
            return null;
        }

        /// <summary>
        /// Retrieves list of the all buy offers.
        /// </summary>
        /// <returns>List of the all buy offers and backend statistics.</returns>
        [HttpGet("buy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<BuyOfferViewModel>>> GetBuy()
        {
            return null;
        }

        /// <summary>
        /// Retrieves buy offer with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested buy offer.</param>
        /// <returns>Buy offer with the specified ID and backend statistics if success, otherwise 404 when not found.</returns>
        [HttpGet("buy/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<BuyOfferViewModel>> GetBuy(int id)
        {
            return null;
        }

        /// <summary>
        /// Adds buy offer passed in the request body.
        /// </summary>
        /// <param name="order">Buy offer which will be added.</param>
        /// <returns>Backend statistics.</returns>
        [HttpPost("buy")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> PostBuy([FromBody] EditBuyOfferViewModel order)
        {
            return null;
        }

        /// <summary>
        /// Deletes buy offer with the specified ID.
        /// </summary>
        /// <param name="id">ID of the buy offer which will be deleted.</param>
        /// <returns>Backend statistics if success, otherwise 404 when ID was not found.</returns>
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