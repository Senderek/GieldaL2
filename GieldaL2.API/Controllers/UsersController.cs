using System;
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
    /// Users controller containing endpoints to manage users.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBuyOfferService _buyOfferService;
        private readonly ISellOfferService _sellOfferService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">User service.</param>
        /// <param name="buyOfferService">Buy offers service.</param>
        /// <param name="sellOfferService">Sell offers service.</param>
        public UsersController(IUserService userService, IBuyOfferService buyOfferService, ISellOfferService sellOfferService)
        {
            _userService = userService;
            _buyOfferService = buyOfferService;
            _sellOfferService = sellOfferService;
        }

        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>List of the all users and backend statistics.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<UserViewModel>>> Get()
        {
            var statisticsDto = new StatisticsDTO();
            var data = _userService.GetAllUsers(statisticsDto).Select(p => Mapper.Map<UserViewModel>(p)).ToList();

            var statistics = Mapper.Map<StatisticsViewModel<IEnumerable<UserViewModel>>>(statisticsDto);
            statistics.Data = data;

            return statistics;
        }

        /// <summary>
        /// Retrieves user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested user.</param>
        /// <returns>User with the specified ID and backend statistics if success, otherwise 404 when not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<UserViewModel>> Get(int id)
        {
            var statisticsDto = new StatisticsDTO();
            var userDto = _userService.GetUserById(id, statisticsDto);

            if (userDto == null)
            {
                return NotFound(Mapper.Map<StatisticsViewModel>(statisticsDto));
            }

            var statistics = Mapper.Map<StatisticsViewModel<UserViewModel>>(statisticsDto);
            statistics.Data = Mapper.Map<UserViewModel>(userDto);

            return statistics;
        }

        /// <summary>
        /// Retrieves shares assigned to the specified user.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>Shares of the specified user.</returns>
        [HttpGet("{id}/shares")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<ShareViewModel>>> GetShares(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves sell offers assigned to the specified user.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>Sell offers of the specified user.</returns>
        [HttpGet("{id}/offers/sell")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<SellOfferViewModel>>> GetSellOffers(int id)
        {
            var statisticsDto = new StatisticsDTO();
            var userDto = _userService.GetUserById(id, statisticsDto);
            if (userDto == null)
            {
                return NotFound(statisticsDto);
            }

            var sellOffersDto = _sellOfferService.GetByUserId(userDto.Id, statisticsDto);
            var statistics = Mapper.Map<StatisticsViewModel<IEnumerable<SellOfferViewModel>>>(statisticsDto);
            statistics.Data = sellOffersDto.Select(p => Mapper.Map<SellOfferViewModel>(p)).ToList();

            return statistics;
        }

        /// <summary>
        /// Retrieves buy offers assigned to the specified user.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>Buy offers of the specified user.</returns>
        [HttpGet("{id}/offers/buy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<BuyOfferViewModel>>> GetBuyOffers(int id)
        {
            var statisticsDto = new StatisticsDTO();
            var userDto = _userService.GetUserById(id, statisticsDto);
            if (userDto == null)
            {
                return NotFound(statisticsDto);
            }

            var buyOffersDto = _buyOfferService.GetByUserId(userDto.Id, statisticsDto);
            var statistics = Mapper.Map<StatisticsViewModel<IEnumerable<BuyOfferViewModel>>>(statisticsDto);
            statistics.Data = buyOffersDto.Select(p => Mapper.Map<BuyOfferViewModel>(p)).ToList();

            return statistics;
        }

        /// <summary>
        /// Adds user passed in the request body.
        /// </summary>
        /// <param name="user">User which will be added.</param>
        /// <returns>Backend statistics.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Post([FromBody] EditUserViewModel user)
        {
            var statisticsDto = new StatisticsDTO();
            _userService.AddUser(Mapper.Map<UserDTO>(user), statisticsDto);

            Response.StatusCode = 201;
            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

        /// <summary>
        /// Edits user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the user which will be edited.</param>
        /// <param name="user">New data which will be applied to the user.</param>
        /// <returns>Backend statistics if user has been modified with success, otherwise 404 if not found.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Put(int id, [FromBody] EditUserViewModel user)
        {
            var statisticsDto = new StatisticsDTO();
            var userDto = _userService.GetUserById(id, statisticsDto);

            if (userDto == null)
            {
                return NotFound(Mapper.Map<StatisticsViewModel>(statisticsDto));
            }

            userDto = Mapper.Map<UserDTO>(user);
            _userService.EditUser(id, userDto, statisticsDto);

            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

        /// <summary>
        /// Deletes user with the specified ID.
        /// </summary>
        /// <param name="id">ID of the user which will be deleted.</param>
        /// <returns>Backend statistics if user has been deleted with success, otherwise 404 if not found.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Delete(int id)
        {
            var statisticsDto = new StatisticsDTO();
            if (!_userService.DeleteUser(id, statisticsDto))
            {
                return NotFound(Mapper.Map<StatisticsViewModel>(statisticsDto));
            }
            
            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }
    }
}
