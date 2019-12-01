using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.DTO
{
	public class ShareDTO
	{
		public int Id { get; set; }
		public int StockId { get; set; }
		public int OwnerId { get; set; }
		/// <summary>
		/// Reduntant for historical reasons :)
		/// </summary>
		public int UserId { get => OwnerId; set { OwnerId = value; } }
		public int Amount { get; set; }
	}
}
