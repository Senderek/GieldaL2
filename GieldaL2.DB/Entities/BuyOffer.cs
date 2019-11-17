using System;

namespace GieldaL2.DB.Entities
{


	public class BuyOffer
	{
		public int Id { get; set; }
		/// <summary>
		/// User who created the offer
		/// </summary>
		public virtual User Buyer { get; set; }
		/// <summary>
		/// Stock that is offered to be bought
		/// </summary>
		public virtual Stock Stock { get; set; }
		/// <summary>
		/// Amount of shares that the user is willing to buy
		/// </summary>
		public int Amount { get; set; }
		/// <summary>
		/// Price that the buyer is willing to pay for a single share
		/// </summary>
		public decimal Price { get; set; }
        /// <summary>
		/// Date of making buy offer
		/// </summary>
		public DateTime Date { get; set; }
	}
}
