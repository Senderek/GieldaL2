using GieldaL2.INFRASTRUCTURE.DTO;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    public interface IStockExchangeLogic : IService
    {
        void ExecuteBuyOffers(SellOfferDTO sellOffer, UserDTO currentUser, StatisticsDTO statistics);
        void ExecuteSellOffers(BuyOfferDTO buyOffer, UserDTO currentUser, StatisticsDTO statistics);
    }
}