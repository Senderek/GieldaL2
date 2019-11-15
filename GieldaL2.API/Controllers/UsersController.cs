using System.Collections.Generic;
using System.Linq;
using System.Net;
using GieldaL2.API.ViewModels.Edit;
using GieldaL2.API.ViewModels.View;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using GieldaL2.INFRASTRUCTURE.Services;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace GieldaL2.API.Controllers
{
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
            var data = _userService.GetAllUsers().Select(p => Mapper.Map<UserViewModel>(p)).ToList();
            return new StatisticsViewModel<IEnumerable<UserViewModel>>
            {
                Data = data
            };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel<UserViewModel>> Get(int id)
        {
            var userDto = _userService.GetUserById(id);
            if (userDto == null)
            {
                return new NotFoundResult();
            }

            return new StatisticsViewModel<UserViewModel>
            {
                Data = Mapper.Map<UserViewModel>(userDto)
            };
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
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Post([FromBody] EditUserViewModel user)
        {
            _userService.AddUser(Mapper.Map<UserDTO>(user));
            return new StatisticsViewModel();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Put(int id, [FromBody] EditUserViewModel user)
        {
            var userDto = _userService.GetUserById(id);
            if (userDto == null)
            {
                return new NotFoundResult();
            }

            userDto = Mapper.Map<UserDTO>(user);
            _userService.AddUser(userDto);

            return new StatisticsViewModel();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StatisticsViewModel> Delete(int id)
        {
            if (!_userService.DeleteUser(id))
            {
                return new NotFoundResult();
            }

            return new StatisticsViewModel();
        }
    }
}
