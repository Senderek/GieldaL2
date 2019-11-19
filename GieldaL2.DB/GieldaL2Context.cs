
using GieldaL2.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace GieldaL2.DB
{
    public class GieldaL2Context : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
		/// <summary>
		/// Transactions history
		/// </summary>
		public virtual DbSet<Transaction> Transactions { get; set; }
		/// <summary>
		/// List of all companies traded on the market
		/// </summary>
		public virtual DbSet<Stock> Stocks { get; set; }
		/// <summary>
		/// List of all shares (parts of company owned by specific user)
		/// </summary>
		public virtual DbSet<Share> Shares { get; set; }

		public virtual DbSet<BuyOffer> BuyOffers { get; set; }
		public virtual DbSet<SellOffer> SellOffers { get; set; }

        public GieldaL2Context(DbContextOptions<GieldaL2Context> options) : base(options)
        {


        }

        public static GieldaL2Context Create(DbContextOptions<GieldaL2Context> options)
        {
            return new GieldaL2Context(options);
        }
    }
}
