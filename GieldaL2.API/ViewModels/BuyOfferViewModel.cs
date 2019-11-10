namespace GieldaL2.API.ViewModels
{
    public class BuyOfferViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StockId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}