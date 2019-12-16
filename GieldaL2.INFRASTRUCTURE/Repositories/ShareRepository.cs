using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class ShareRepository : IShareRepository
    {
        /// <summary>
        /// Property that stores last  operation time on database
        /// </summary>
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context context;

        public ShareRepository(GieldaL2Context context)
        {
            this.context = context;            
        }

        /// <summary>
        /// Method that returns specific Share entity
        /// </summary>
        /// <param name="id">Identifier of Share</param>
        /// <returns>Singular Share entity</returns>
        public Share GetById(int id)
		{
			var watch = Stopwatch.StartNew();
			var d = context.Shares.FirstOrDefault(share => share.Id == id);
			LastOperationTime = (int)watch.ElapsedMilliseconds;
			return d;
        }

        /// <summary>
        /// Method that returns Collection of Share entities
        /// </summary>
        /// <returns>Collection of Share entities</returns>
        public ICollection<Share> GetAll()
		{
			var watch = Stopwatch.StartNew();
			var d = context.Shares.ToList();
			LastOperationTime = (int)watch.ElapsedMilliseconds;
			return d;
        }

        /// <summary>
        /// Method that returns Collection of Share entities for the specified user.
        /// </summary>
        /// <returns>Collection of Share entities for the specified user.</returns>
        public ICollection<Share> GetByUserId(int userId)
        {
            var watch = Stopwatch.StartNew();
            var d = context.Shares.Where(p => p.OwnerId == userId).ToList();
            LastOperationTime = (int)watch.ElapsedMilliseconds;
            return d;
        }

        /// <summary>
        /// Method for adding Share entity to database
        /// </summary>
        /// <param name="share">Share entity to add</param>
        public void Add(Share share)
		{
			var watch = Stopwatch.StartNew();
			context.Add(share);
			context.SaveChanges();
			LastOperationTime = (int)watch.ElapsedMilliseconds;
		}

		/// <summary>
		/// Sets share owner by id. (does not save changes)
		/// </summary>
		/// <param name="share"></param>
		/// <param name="ownerid"></param>
		public void SetShareOwnerById(Share share, int ownerid)
		{
			share.Owner = context.Users.Find(ownerid);
		}

		/// <summary>
		/// Sets share stock by id. (does not save changes)
		/// </summary>
		/// <param name="share"></param>
		/// <param name="ownerid"></param>
		public void SetShareStockById(Share share, int stockid)
		{
			share.Stock = context.Stocks.Find(stockid);
		}

		/// <summary>
		/// Method for modifying Share entity
		/// </summary>
		/// <param name="share">Share entity to modify</param>
		public void Edit(Share share)
		{
			var watch = Stopwatch.StartNew();
			context.SaveChanges();
			LastOperationTime = (int)watch.ElapsedMilliseconds;
		}

        /// <summary>
        /// Method for removing Share entity from database
        /// </summary>
        /// <param name="share">Share entity to remove</param>
        public void Remove(Share share)
		{
			var watch = Stopwatch.StartNew();
			context.Remove(share);
            context.SaveChanges();
			LastOperationTime = (int)watch.ElapsedMilliseconds;
		}
    }
}
