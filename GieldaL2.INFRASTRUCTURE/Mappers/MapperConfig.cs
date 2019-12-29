using GieldaL2.DB.Entities;
using GieldaL2.INFRASTRUCTURE.DTO;
using Omu.ValueInjecter;
using System;

namespace GieldaL2.INFRASTRUCTURE.Mappers
{
    /// <summary>
    /// Mapper configurator which initializes ValueInjecter maps.
    /// </summary>
    public static class MapperConfig
    {
        /// <summary>
        /// Creates maps for the ValueInjecter library.
        /// </summary>
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

            Mapper.AddMap<Transaction, TransactionDTO>(src => new TransactionDTO
            {
                Id = src.Id,
                BuyerId = src.BuyerId,
                SellerId = src.SellerId,
                StockId = src.StockId,
                Amount = src.Amount,
                Price = src.Price,
                Date = src.Date
            });

            Mapper.AddMap<SellOffer, SellOfferDTO>(src => new SellOfferDTO
            {
                Id = src.Id,
                SellerId = src.SellerId,
                ShareId = src.ShareId,
                Amount = src.Amount,
                Price = src.Price,
                Date = DateTime.SpecifyKind(src.Date, DateTimeKind.Utc)
            });

            Mapper.AddMap<BuyOffer, BuyOfferDTO>(src => new BuyOfferDTO
            {
                Id = src.Id,
                BuyerId = src.BuyerId,
                StockId = src.StockId,
                Amount = src.Amount,
                Price = src.Price,
                Date = DateTime.SpecifyKind(src.Date, DateTimeKind.Utc)
            });
        }
    }
}
