using System;

namespace GieldaL2.DB.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
		/// <summary>
		/// Who bought
		/// </summary>
        public virtual User Buyer { get; set; }
		/// <summary>
		/// Who sold
		/// </summary>
		public virtual User Seller { get; set; }
		/// <summary>
		/// Stock that was the object of the transaction
		/// </summary>
		public virtual Stock Stock { get; set; }
		/// <summary>
		/// Number of shares that changed owner
		/// </summary>
		public int Amount { get; set; }
		/// <summary>
		/// Price paid per share
		/// </summary>
        public decimal Price { get; set; }
		/// <summary>
		/// Time of when the transaction happened
		/// </summary>
        public DateTime Date { get; set; }
    }
}
