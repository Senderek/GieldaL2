using System;
using System.Collections.Generic;

namespace GieldaL2.DB.Entities
{
	/// <summary>
	/// Represents single tradeable entity (eg. company)
	/// </summary>
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
		virtual public List<Share> Shares { get; set; }
		/// <summary>
		/// Current computed value of single share of this company
		/// </summary>
		public decimal CurrentPrice { get; set; }

		/// <summary>
		/// Last change in company's  shares value
		/// </summary>
		public decimal PriceDelta { get; set; }
	}
}
