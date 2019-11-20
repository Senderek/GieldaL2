using System.Collections.Generic;
using System.Linq;
using GieldaL2.API.ViewModels.View;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace GieldaL2.API.Controllers
{
    /// <summary>
    /// Controller that includes endpoints for transactions
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Action that returns Collection of TransactionViewModels
        /// </summary>
        /// <returns>Collection of Transaction ViewModels</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<TransactionViewModel>>> Get()
        {
            var statisticsDto = new StatisticsDTO();
            var transactions = _transactionService.GetAll(statisticsDto).Select(t => Mapper.Map<TransactionViewModel>(t)).ToList();

            var statistics = Mapper.Map<StatisticsViewModel<IEnumerable<TransactionViewModel>>>(statisticsDto);
            statistics.Data = transactions;

            return statistics;
        }

        /// <summary>
        /// Action that returns specific TransactionViewModel
        /// </summary>
        /// <param name="id">identifier of transaction</param>
        /// <returns>Singular Transaction ViewModel</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<TransactionViewModel>> Get(int id)
        {
            var statisticsDto = new StatisticsDTO();
            var transaction = _transactionService.GetById(id, statisticsDto);

            var statistics = Mapper.Map<StatisticsViewModel<TransactionViewModel>>(statisticsDto);

            if (transaction == null)
            {
                return NotFound(statistics);
            }

            statistics.Data = Mapper.Map<TransactionViewModel>(transaction);

            return statistics;
        }

        /// <summary>
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