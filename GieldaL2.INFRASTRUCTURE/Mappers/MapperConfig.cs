using GieldaL2.DB.Entities;
using GieldaL2.INFRASTRUCTURE.DTO;
using Omu.ValueInjecter;

namespace GieldaL2.INFRASTRUCTURE.Mappers
{
    public static class MapperConfig
    {
        public static void Init()
        {
            Mapper.AddMap<UserDTO, User>(src => new User
            {
                Id = src.Id,
                Name = src.Name,
                Surname = src.Surname,
                UserName = src.Login,
                Password = src.Password,
                EMail = src.EMail,
                Money = src.Value
            });

            Mapper.AddMap<User, UserDTO>(src => new UserDTO
            {
                Id = src.Id,
                Name = src.Name,
                Value = src.Money,
                Login = src.UserName,
                EMail = src.EMail,
                Password = src.Password,
                Surname = src.Surname
            });
        }
    }
}
