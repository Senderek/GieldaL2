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
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OffersController : ControllerBase
    {
        private readonly ISellOfferService _sellOfferService;
        public OffersController(ISellOfferService sellOfferService)
        {
            _sellOfferService = sellOfferService;
        }

        [HttpGet("sell")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<SellOfferViewModel>>> GetSell()
        {
            var statisticsDto = new StatisticsDTO();
            var sellOfferDto = _sellOfferService.GetAll(statisticsDto).Select(s => Mapper.Map<SellOfferViewModel>(s)).ToList();

            var statistics = Mapper.Map<StatisticsViewModel<IEnumerable<SellOfferViewModel>>>(statisticsDto);
            statistics.Data = sellOfferDto;

            return statistics;
        }

        [HttpGet("sell/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<SellOfferViewModel>> GetSell(int id)
        {
            var statisticsDto = new StatisticsDTO();
            var sellOfferDto = _sellOfferService.GetById(id, statisticsDto);

            var statistics = Mapper.Map<StatisticsViewModel<SellOfferViewModel>>(statisticsDto);

            if (sellOfferDto == null)
            {
                return NotFound(statistics);
            }

            statistics.Data = Mapper.Map<SellOfferViewModel>(sellOfferDto);

            return statistics;
        }

        [HttpPost("sell")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> PostSell([FromBody] EditSellOfferViewModel sellOffer)
        {
            var statisticsDto = new StatisticsDTO();
            _sellOfferService.Add(Mapper.Map<SellOfferDTO>(sellOffer), statisticsDto);
            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

        [HttpDelete("sell/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> DeleteSell(int id)
        {
            var statisticsDto = new StatisticsDTO();
            if (!_sellOfferService.Delete(id, statisticsDto))
            {
                return new NotFoundResult();
            }

            return Mapper.Map<StatisticsViewModel>(statisticsDto);
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