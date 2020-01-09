using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IUserService _userService;
        private readonly IShareService _shareService;
        private readonly IStockService _stockService;
        private readonly IStockExchangeLogic _stockExchangeLogic;

        public OffersController(ISellOfferService sellOfferService, IBuyOfferService buyOfferService, IUserService userService, IShareService shareService, IStockService stockService, IStockExchangeLogic stockExchangeLogic)
        {
            _sellOfferService = sellOfferService;
            _buyOfferService = buyOfferService;
            _userService = userService;
            _shareService = shareService;
            _stockService = stockService;
            _stockExchangeLogic = stockExchangeLogic;
        }

        /// <summary>
        /// Retrieves list of all sell offers
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
        /// Retrieves specified sell offer
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
            var currentUserName = User.FindFirst(ClaimTypes.Name).Value;
            var currentUserDto = _userService.GetUserByName(currentUserName, statisticsDto);

            _stockExchangeLogic.FindBuyOffers(Mapper.Map<SellOfferDTO>(sellOffer), currentUserDto, statisticsDto);

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
            var currentUserName = User.FindFirst(ClaimTypes.Name).Value;
            var currentUserDto = _userService.GetUserByName(currentUserName, statisticsDto);

            var sellOfferToDelete = _sellOfferService.GetById(id, statisticsDto);

            if (sellOfferToDelete != null)
            {
                if (currentUserDto.Id == sellOfferToDelete.SellerId)
                {
                    if (_sellOfferService.Delete(id, statisticsDto))
                    {
                        //if offer exists, belongs to user and is sucessfully deleted add amount to share amount
                        var share = _shareService.GetShareById(sellOfferToDelete.ShareId, statisticsDto);
                        share.Amount += sellOfferToDelete.Amount;
                        _shareService.EditShare(share.Id, share, statisticsDto);
                        return Mapper.Map<StatisticsViewModel>(statisticsDto);
                    }
                }
            }
            
            return NotFound(Mapper.Map<StatisticsViewModel>(statisticsDto));

        }

        /// <summary>
        /// Retrieves list of all buy offers
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
        /// Retrieves specified buy offer
        /// </summary>
        /// <param name="id">buy offer id</param>
        /// <returns>offer with specified id</returns>
        [HttpGet("buy/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [AllowAnonymous]
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
            var currentUserName = User.FindFirst(ClaimTypes.Name).Value;
            var currentUserDto = _userService.GetUserByName(currentUserName, statisticsDto);

            _stockExchangeLogic.FindSellOffers(Mapper.Map<BuyOfferDTO>(buyOffer), currentUserDto, statisticsDto);

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
            var currentUserName = User.FindFirst(ClaimTypes.Name).Value;
            var currentUserDto = _userService.GetUserByName(currentUserName, statisticsDto);

            var buyOfferToDelete = _buyOfferService.GetById(id, statisticsDto);

            if (buyOfferToDelete != null)
            {
                if (buyOfferToDelete.BuyerId == currentUserDto.Id)
                {
                    if (_buyOfferService.Delete(buyOfferToDelete.Id, statisticsDto))
                    {
                        currentUserDto.Value += buyOfferToDelete.Price * buyOfferToDelete.Amount;
                        currentUserDto.Password = null;

                        if (_userService.EditUser(currentUserDto.Id, currentUserDto, statisticsDto))
                        {
                            return Mapper.Map<StatisticsViewModel>(statisticsDto);
                        }                     
                    }
                }
            }
            return NotFound(Mapper.Map<StatisticsViewModel>(statisticsDto));
        }
    }
}