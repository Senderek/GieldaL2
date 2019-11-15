using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace GieldaL2.INFRASTRUCTURE.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            // TODO: move to the another location if necessary
            var key = Encoding.ASCII.GetBytes("secret-key");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
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
