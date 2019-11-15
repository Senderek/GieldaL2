using GieldaL2.API.ViewModels.View;
using GieldaL2.DB.Interfaces;
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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<AuthResultViewModel> LogIn(LogInViewModel viewModel)
        {
            var authDto = Mapper.Map<AuthDTO>(viewModel);
            if (_authService.LogIn(authDto, out string token))
            {
                return new AuthResultViewModel
                {
                    Success = true,
                    Token = token
                };
            }

            return new AuthResultViewModel
            {
                Success = false,
                Token = string.Empty
            };
        }
    }
}
