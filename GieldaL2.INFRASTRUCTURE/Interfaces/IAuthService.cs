using GieldaL2.INFRASTRUCTURE.DTO;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    /// <summary>
    /// Interface for the service containing methods to authenticate users.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates user and generates JWT token.
        /// </summary>
        /// <param name="authDto">DTO containing authentication data.</param>
        /// <param name="token">JWT token (generated when user passed valid login and password, otherwise null).</param>
        /// <returns>True if user has been authenticated with success, otherwise false.</returns>
        bool LogIn(AuthDTO authDto, out string token);
        
        string HashPassword(string password);
    }
}
