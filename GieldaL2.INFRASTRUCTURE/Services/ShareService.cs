using System.Collections.Generic;
using System.Linq;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Omu.ValueInjecter;

namespace GieldaL2.INFRASTRUCTURE.Services
{
	public class ShareService : IShareService
	{
		private readonly IShareRepository repo;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserService"/> class.
		/// </summary>
		/// <param name="userRepository">Repository containing users.</param>
		public ShareService(IShareRepository repository)
		{
			this.repo = repository;
		}

		public void AddShare(ShareDTO share, StatisticsDTO statistics)
		{
			var ns = Mapper.Map<Share>(share);
			repo.Add(ns);
			statistics.InsertsTime += repo.LastOperationTime;
			statistics.InsertsCount++;
		}

		public bool DeleteShare(int id, StatisticsDTO statistics)
		{
			var share = repo.GetById(id);
			statistics.SelectsTime += repo.LastOperationTime;
			statistics.SelectsCount++;

			if (share == null)
			{
				return false;
			}

			repo.Remove(share);
			statistics.DeletesTime += repo.LastOperationTime;
			statistics.DeletesCount++;

			return true;
		}

		public bool EditShare(int id, ShareDTO share, StatisticsDTO statistics)
		{
			var edited = repo.GetById(id);
			statistics.SelectsTime += repo.LastOperationTime;
			statistics.SelectsCount++;

			if (edited == null)
			{
				return false;
			}

			edited.OwnerId = share.OwnerId;
			edited.StockId = share.StockId;
			edited.Amount = share.Amount;

			repo.Edit(edited);
			statistics.UpdatesTime += repo.LastOperationTime;
			statistics.UpdatesCount++;

			return true;
		}

		public ICollection<ShareDTO> GetAllShares(StatisticsDTO statistics)
		{
			var shares = repo.GetAll().Select(p => Mapper.Map<ShareDTO>(p)).ToList();
			statistics.SelectsTime += repo.LastOperationTime;
			statistics.SelectsCount++;

			return shares;
		}

		public ShareDTO GetShareById(int id, StatisticsDTO statistics)
		{
			var share = repo.GetById(id);
			statistics.SelectsTime += repo.LastOperationTime;
			statistics.SelectsCount++;

			if (share == null)
			{
				return null;
			}

			return Mapper.Map<ShareDTO>(share);
		}
	}
}
