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
    public class AuthService : IService, IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _settings;

        public AuthService(IUserRepository userRepository, IOptions<AppSettings> settings)
        {
            _userRepository = userRepository;
            _settings = settings.Value;
        }

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
