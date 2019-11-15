using System;
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
        }
    }
}
