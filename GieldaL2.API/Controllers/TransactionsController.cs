using System.Collections.Generic;
using GieldaL2.API.ViewModels.View;
using Microsoft.AspNetCore.Mvc;

namespace GieldaL2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TransactionsController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<TransactionViewModel>> Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<TransactionViewModel> Get(int id)
        {
            return null;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public void Post([FromBody] TransactionViewModel order)
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