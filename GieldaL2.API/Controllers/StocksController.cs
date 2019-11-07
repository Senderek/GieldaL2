using System.Collections.Generic;
using GieldaL2.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GieldaL2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StocksController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<StockViewModel>> Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StockViewModel> Get(int id)
        {
            return null;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public void Post([FromBody] EditStockViewModel user)
        {
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public void Put(int id, [FromBody] EditStockViewModel user)
        {
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public void Delete(int id)
        {
        }
    }
}
