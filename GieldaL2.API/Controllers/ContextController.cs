using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GieldaL2.API.ViewModels.View;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace GieldaL2.API.Controllers
{
    /// <summary>
    /// Context controller containing endpoints which retrieves full data about the user.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ContextController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBuyOfferService _buyOfferService;
        private readonly ISellOfferService _sellOfferService;
        private readonly IShareService _shareService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextController"/> class.
        /// </summary>
        /// <param name="userService">User service.</param>
        /// <param name="buyOfferService">Buy offer service.</param>
        /// <param name="sellOfferService">Sell offer service.</param>
        public ContextController(IUserService userService, IBuyOfferService buyOfferService, ISellOfferService sellOfferService, IShareService shareService)
        {
            _userService = userService;
            _buyOfferService = buyOfferService;
            _sellOfferService = sellOfferService;
            _shareService = shareService;
        }

        /// <summary>
        /// Retrieves user and his offers/shares (based on the JWT token).
        /// </summary>
        /// <returns>User data and his offers/shares.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<ContextViewModel>> Get()
        {
            var statisticsDto = new StatisticsDTO();
            var currentUserName = User.FindFirst(ClaimTypes.Name).Value;
            var currentUserDto = _userService.GetUserByName(currentUserName, statisticsDto);
            var currentUserBuyOffersDto = _buyOfferService.GetByUserId(currentUserDto.Id, statisticsDto);
            var currentUserSellOffersDto = _sellOfferService.GetByUserId(currentUserDto.Id, statisticsDto);
            var currentUserShares = _shareService.GetByUserId(currentUserDto.Id, statisticsDto);

            var statistics = Mapper.Map<StatisticsViewModel<ContextViewModel>>(statisticsDto);
            statistics.Data = new ContextViewModel
            {
                User = Mapper.Map<UserViewModel>(currentUserDto),
                Shares = currentUserShares.Select(p => Mapper.Map<ShareViewModel>(p)).ToList(),
                BuyOffers = currentUserBuyOffersDto.Select(p => Mapper.Map<BuyOfferViewModel>(p)).ToList(),
                SellOffers = currentUserSellOffersDto.Select(p => Mapper.Map<SellOfferViewModel>(p)).ToList()
            };

            return statistics;
        }
    }
}