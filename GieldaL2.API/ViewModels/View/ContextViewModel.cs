using System.Collections.Generic;

namespace GieldaL2.API.ViewModels.View
{
    public class ContextViewModel
    {
        public UserViewModel User { get; set; }
        public List<ShareViewModel> Shares { get; set; }
        public List<BuyOfferViewModel> BuyOffers { get; set; }
        public List<SellOfferViewModel> SellOffers { get; set; }
    }
}
