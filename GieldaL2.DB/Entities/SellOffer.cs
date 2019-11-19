using System;

namespace GieldaL2.DB.Entities
{
	public class SellOffer
	{
		public int Id { get; set; }
		/// <summary>
		/// Shares that are offered for sale
		/// </summary>
		public virtual Share Share { get; set; }
		/// <summary>
		/// Number of shares offered
		/// </summary>
		public int Amount { get; set; }
		/// <summary>
		/// Price per share
		/// </summary>
		public decimal Price { get; set; }
		public DateTime Date { get; set; }
	}

}
