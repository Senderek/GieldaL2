

namespace GieldaL2.INFRASTRUCTURE.DTO
{
    public class StockDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public decimal CurrentPrice { get; set; }
		public decimal PriceDelta { get; set; }
	}
}
