using System.Collections.Generic;
using System.Linq;
using GieldaL2.API.ViewModels.Edit;
using GieldaL2.API.ViewModels.View;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace GieldaL2.API.Controllers
{
    /// <summary>
    /// Controller for handling all of the sell offer and buy offer operations
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OffersController : ControllerBase
    {
        private readonly ISellOfferService _sellOfferService;
        private readonly IBuyOfferService _buyOfferService;
        public OffersController(ISellOfferService sellOfferService, IBuyOfferService buyOfferService)
        {
            _sellOfferService = sellOfferService;
            _buyOfferService = buyOfferService;
        }

        /// <summary>
        /// Retrives list of all sell offers
        /// </summary>
        /// <returns>List of sell offers</returns>
        [HttpGet("sell")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<SellOfferViewModel>>> GetSell()
        {
            var statisticsDto = new StatisticsDTO();
            var offerDto = _sellOfferService.GetAll(statisticsDto).Select(s => Mapper.Map<SellOfferViewModel>(s)).ToList();

            var statistics = Mapper.Map<StatisticsViewModel<IEnumerable<SellOfferViewModel>>>(statisticsDto);
            statistics.Data = offerDto;

            return statistics;
        }

        /// <summary>
        /// Retrives specified sell offer
        /// </summary>
        /// <param name="id">sell offer id</param>
        /// <returns>offer with specified id</returns>
        [HttpGet("sell/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<SellOfferViewModel>> GetSell(int id)
        {
            var statisticsDto = new StatisticsDTO();
            var offerDto = _sellOfferService.GetById(id, statisticsDto);

            var statistics = Mapper.Map<StatisticsViewModel<SellOfferViewModel>>(statisticsDto);

            if (offerDto == null)
            {
                return NotFound(statistics);
            }

            statistics.Data = Mapper.Map<SellOfferViewModel>(offerDto);

            return statistics;
        }

        /// <summary>
        /// Adds sell offer passed in request body
        /// </summary>
        /// <param name="sellOffer">Sell offer to add</param>
        /// <returns>Backend statistics</returns>
        [HttpPost("sell")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> PostSell([FromBody] EditSellOfferViewModel sellOffer)
        {
            var statisticsDto = new StatisticsDTO();
            _sellOfferService.Add(Mapper.Map<SellOfferDTO>(sellOffer), statisticsDto);
            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

        /// <summary>
        /// Deletes sell offer specified by id
        /// </summary>
        /// <param name="id">id of sell offer to delete</param>
        /// <returns>backend statistics</returns>
        [HttpDelete("sell/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> DeleteSell(int id)
        {
            var statisticsDto = new StatisticsDTO();
            if (!_sellOfferService.Delete(id, statisticsDto))
            {
                return NotFound(statisticsDto);
            }

            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

        /// <summary>
        /// Retrives list of all buy offers
        /// </summary>
        /// <returns>List of buy offers</returns>
        [HttpGet("buy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<BuyOfferViewModel>>> GetBuy()
        {
            var statisticsDto = new StatisticsDTO();
            var offerDto = _buyOfferService.GetAll(statisticsDto).Select(s => Mapper.Map<BuyOfferViewModel>(s)).ToList();

            var statistics = Mapper.Map<StatisticsViewModel<IEnumerable<BuyOfferViewModel>>>(statisticsDto);
            statistics.Data = offerDto;

            return statistics;
        }

        /// <summary>
        /// Retrives specified buy offer
        /// </summary>
        /// <param name="id">buy offer id</param>
        /// <returns>offer with specified id</returns>
        [HttpGet("buy/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<BuyOfferViewModel>> GetBuy(int id)
        {
            var statisticsDto = new StatisticsDTO();
            var offerDto = _buyOfferService.GetById(id, statisticsDto);

            var statistics = Mapper.Map<StatisticsViewModel<BuyOfferViewModel>>(statisticsDto);

            if (offerDto == null)
            {
                return NotFound(statistics);
            }

            statistics.Data = Mapper.Map<BuyOfferViewModel>(offerDto);

            return statistics;
        }

        /// <summary>
        /// Adds buy offer passed in request body
        /// </summary>
        /// <param name="buyOffer">Buy offer to add</param>
        /// <returns>backend statistics</returns>
        [HttpPost("buy")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> PostBuy([FromBody] EditBuyOfferViewModel buyOffer)
        {
            var statisticsDto = new StatisticsDTO();
            _buyOfferService.Add(Mapper.Map<BuyOfferDTO>(buyOffer), statisticsDto);
            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

        /// <summary>
        /// Deletes buy offer specified by id
        /// </summary>
        /// <param name="id">id of buy offer to delete</param>
        /// <returns>backend statistics</returns>
        [HttpDelete("buy/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> DeleteBuy(int id)
        {
            var statisticsDto = new StatisticsDTO();
            if (!_buyOfferService.Delete(id, statisticsDto))
            {
                return NotFound(statisticsDto);
            }

            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }
    }
}