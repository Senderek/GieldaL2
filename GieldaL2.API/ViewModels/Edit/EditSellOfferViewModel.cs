﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels.Edit
{
    public class EditSellOfferViewModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ShareId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

		[Required]
		public DateTime Date { get; set; }
	}
}