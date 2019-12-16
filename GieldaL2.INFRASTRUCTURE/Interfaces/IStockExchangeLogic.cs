using GieldaL2.INFRASTRUCTURE.DTO;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
    public interface IStockExchangeLogic : IService
    {
        void FindBuyOffers(SellOfferDTO sellOffer, UserDTO currentUser, StatisticsDTO statistics);
        void FindSellOffers(BuyOfferDTO buyOffer, UserDTO currentUser, StatisticsDTO statistics);
    }
}