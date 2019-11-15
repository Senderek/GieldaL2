
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GieldaL2.DB.Entities
{
	public class User
	{
        /// <summary>
        /// User's ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password hash
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User's e-mail
        /// </summary>
        public string EMail { get; set; }
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
