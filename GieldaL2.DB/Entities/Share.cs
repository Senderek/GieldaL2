namespace GieldaL2.DB.Entities
{
	/// <summary>
	/// Represents some number of shares of a company owned by a particular user 
	/// </summary>
	public class Share
	{
		public int Id { get; set; }
		/// <summary>
		/// Owner of the shares
		/// </summary>
		virtual public User Owner { get; set; }
		public int Amount { get; set; }
		/// <summary>
		/// Represents a company which the shares represent
		/// </summary>
		virtual public Stock Stock { get; set; } 
	}
}