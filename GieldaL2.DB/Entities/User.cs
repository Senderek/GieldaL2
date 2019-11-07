
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GieldaL2.DB.Entities
{
	public class User : IdentityUser
	{
		/// <summary>
		/// Users money
		/// </summary>
		public decimal Money { get; set; }
		/// <summary>
		/// Shares owned by a user
		/// </summary>
		public List<Share> Shares { get; set; }
		/// <summary>
		/// Buy offers added by user
		/// </summary>
		public List<BuyOffer> BuyOffers { get; set; }
		/// <summary>
		/// Sell offers added by user
		/// </summary>
		public List<SellOffer> SellOffers { get; set; }
	}
}
