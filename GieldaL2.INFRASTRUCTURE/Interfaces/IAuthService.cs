using GieldaL2.INFRASTRUCTURE.DTO;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    public interface IAuthService
    {
        bool LogIn(AuthDTO authDto, out string token);
    }
}
