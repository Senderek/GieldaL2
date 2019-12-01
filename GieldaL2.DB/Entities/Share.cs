using System.ComponentModel.DataAnnotations;

namespace GieldaL2.DB.Entities
{
	/// <summary>
	/// Represents some number of shares of a company owned by a particular user 
	/// </summary>
	public class Share
	{
		public int Id { get; set; }
		/// <summary>
		/// ID of the owner of the shares
		/// </summary>
		public int OwnerId { get; set; }
		/// <summary>
		/// Owner of the shares
		/// </summary>
		virtual public User Owner { get; set; }
		/// <summary>
		/// Amount of the shares owned by a specific user
		/// </summary>
		public int Amount { get; set; }
		/// <summary>
		/// ID of the stock the shares are part of.
		/// </summary>
		public int StockId { get; set; }
		/// <summary>
		/// Represents a company which the shares represent
		/// </summary>
		virtual public Stock Stock { get; set; } 
	}
}