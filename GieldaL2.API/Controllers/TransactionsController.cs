using System.Collections.Generic;
using GieldaL2.API.ViewModels.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GieldaL2.API.Controllers
{
    /// <summary>
    /// Transactions controller containing endpoints to manage transactions.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TransactionsController
    {
        /// <summary>
        /// Retrieves a list of all transactions.
        /// </summary>
        /// <returns>List of the all transactions and backend statistics.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<TransactionViewModel>>> Get()
        {
            return null;
        }

        /// <summary>
        /// Retrieves transaction with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested transaction.</param>
        /// <returns>Transaction with the specified ID and backend statistics if success, otherwise 404 when not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<TransactionViewModel>> Get(int id)
        {
            return null;
        }

        /// <summary>T
        /// Adds transaction passed in the request body.
        /// </summary>
        /// <param name="transaction">Transaction which will be added.</param>
        /// <returns>Backend statistics.</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Post([FromBody] TransactionViewModel transaction)
        {
            return null;
        }

        /// <summary>
        /// Deletes transaction with the specified ID.
        /// </summary>
        /// <param name="id">ID of the transaction which will be deleted.</param>
        /// <returns>Backend statistics if transaction has been deleted with success, otherwise 404 if not found.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Delete(int id)
        {
            return null;
        }
    }
}