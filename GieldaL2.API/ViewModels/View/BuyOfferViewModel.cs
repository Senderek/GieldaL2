using System;

namespace GieldaL2.API.ViewModels.View
{
    public class BuyOfferViewModel
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int StockId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
		public DateTime Date { get; set; }
	}
}