using System.Collections.Generic;
using System.Linq;
using System.Net;
using GieldaL2.API.ViewModels.Edit;
using GieldaL2.API.ViewModels.View;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using GieldaL2.INFRASTRUCTURE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace GieldaL2.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

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
                return new NotFoundResult();
            }

            var statistics = Mapper.Map<StatisticsViewModel<UserViewModel>>(statisticsDto);
            statistics.Data = Mapper.Map<UserViewModel>(userDto);

            return statistics;
        }

        [HttpGet("{id}/shares")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<IEnumerable<ShareViewModel>>> GetShares(int id)
        {
            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Post([FromBody] EditUserViewModel user)
        {
            var statisticsDto = new StatisticsDTO();
            _userService.AddUser(Mapper.Map<UserDTO>(user), statisticsDto);

            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

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
                return new NotFoundResult();
            }

            userDto = Mapper.Map<UserDTO>(user);
            _userService.EditUser(id, userDto, statisticsDto);

            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Delete(int id)
        {
            var statisticsDto = new StatisticsDTO();
            if (!_userService.DeleteUser(id, statisticsDto))
            {
                return new NotFoundResult();
            }

            return Mapper.Map<StatisticsViewModel>(statisticsDto);
        }
    }
}
