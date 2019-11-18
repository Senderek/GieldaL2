using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Helpers;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GieldaL2.INFRASTRUCTURE.Services
{
    /// <summary>
    /// Service containing methods to authenticate users.
    /// </summary>
    public class AuthService : IService, IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="userRepository">Repository containing users.</param>
        /// <param name="settings">Data loaded from appsettings.json.</param>
        public AuthService(IUserRepository userRepository, IOptions<AppSettings> settings)
        {
            _userRepository = userRepository;
            _settings = settings.Value;
        }

        /// <summary>
        /// Authenticates user and generates JWT token.
        /// </summary>
        /// <param name="authDto">DTO containing authentication data.</param>
        /// <param name="token">JWT token (generated when user passed valid login and password, otherwise null).</param>
        /// <returns>True if user has been authenticated with success, otherwise false.</returns>
        public bool LogIn(AuthDTO authDto, out string token)
        {
            var user = _userRepository.GetByUserNameAndPassword(authDto.UserName, authDto.Password);

            if (user == null)
            {
                token = null;
                return false;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenContainer = tokenHandler.CreateToken(tokenDescriptor);
            token = tokenHandler.WriteToken(tokenContainer);

            return true;
        }
    }
}
