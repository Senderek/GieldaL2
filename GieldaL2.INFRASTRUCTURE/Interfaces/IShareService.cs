using GieldaL2.INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Interfaces
{
	public interface IShareService	: IService
	{
		/// <summary>
		/// Retrieves all shares from the database.
		/// </summary>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		/// <returns>Collection of retrieved shares from the database.</returns>
		ICollection<ShareDTO> GetAllShares(StatisticsDTO statistics);

		/// <summary>
		/// Retrieves an share with the specified ID.
		/// </summary>
		/// <param name="id">ID of the requested share.</param>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		/// <returns>Share DTO if found, otherwise null.</returns>
		ShareDTO GetShareById(int id, StatisticsDTO statistics);

		/// <summary>
		/// Adds share passed in the parameter to the database.
		/// </summary>
		/// <param name="share">Share DTO which will be added to the database.</param>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		void AddShare(ShareDTO share, StatisticsDTO statistics);

		/// <summary>
		/// Edits share with the specified ID.
		/// </summary>
		/// <param name="id">ID of the share which will be edited.</param>
		/// <param name="share">Share data which will be applied.</param>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		/// <returns>True if share with the specified ID has been found and edited, otherwise false.</returns>
		bool EditShare(int id, ShareDTO share, StatisticsDTO statistics);

		/// <summary>
		/// Deletes share with the specified ID.
		/// </summary>
		/// <param name="id">ID of the share which will be deleted.</param>
		/// <param name="statistics">DTO containing statistics which will be updated during work of this method.</param>
		/// <returns>True if share with the specified ID has been found and deleted, otherwise false.</returns>
		bool DeleteShare(int id, StatisticsDTO statistics);

	}
}
