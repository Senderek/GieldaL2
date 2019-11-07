using System.Collections.Generic;
using GieldaL2.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GieldaL2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OffersController : ControllerBase
    {
        [HttpGet("sell")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<OfferViewModel>> GetSell()
        {
            return null;
        }

        [HttpGet("sell/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<OfferViewModel> GetSell(int id)
        {
            return null;
        }

        [HttpPost("sell")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public void PostSell([FromBody] EditOfferViewModel order)
        {
        }

        [HttpDelete("sell/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public void DeleteSell(int id)
        {
        }

        [HttpGet("buy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<OfferViewModel>> GetBuy()
        {
            return null;
        }

        [HttpGet("buy/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<OfferViewModel> GetBuy(int id)
        {
            return null;
        }

        [HttpPost("buy")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public void PostBuy([FromBody] EditOfferViewModel order)
        {
        }

        [HttpDelete("buy/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public void DeleteBuy(int id)
        {
        }
    }
}