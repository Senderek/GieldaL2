using GieldaL2.API.ViewModels.View;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using GieldaL2.INFRASTRUCTURE.Services;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace GieldaL2.API.Controllers
{
    /// <summary>
    /// Authentication controller containing endpoints to check user identity and generating JWT tokens.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">Authentication service.</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        /// <summary>
        /// Authenticates user and generates JWT token if passed data is valid.
        /// </summary>
        /// <param name="viewModel">Authentication data.</param>
        /// <returns>Flag indicating if authentication has been done with success and JWT token.</returns>
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
