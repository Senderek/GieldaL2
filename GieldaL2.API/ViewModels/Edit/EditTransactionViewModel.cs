using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels.Edit
{
    public class EditTransactionViewModel
    {
        [Required]
        public int BuyerId { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        public int StockId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}