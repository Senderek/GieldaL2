using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.DTO
{
    public class BuyOfferDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StockId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
		public DateTime Date { get; set; }
    }
}
