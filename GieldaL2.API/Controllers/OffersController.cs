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
    //[Authorize]
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
            //w przypadku braku sell oferty wywala exception
            //if (!_sellOfferService.Delete(id, statisticsDto))
            //{
            //    return new NotFoundResult();
            //}
            _sellOfferService.Delete(id, statisticsDto);

            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

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

        [HttpPost("buy")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> PostBuy([FromBody] EditBuyOfferViewModel buyOffer)
        {
            var statisticsDto = new StatisticsDTO();
            _buyOfferService.Add(Mapper.Map<BuyOfferDTO>(buyOffer), statisticsDto);
            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

        [HttpDelete("buy/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> DeleteBuy(int id)
        {
            var statisticsDto = new StatisticsDTO();
            //w przypadku braku sell oferty wywala exception
            //if (!_buyOfferService.Delete(id, statisticsDto))
            //{
            //    return new NotFoundResult();
            //}
            _buyOfferService.Delete(id, statisticsDto);

            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }
    }
}