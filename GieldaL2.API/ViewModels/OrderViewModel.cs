using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public int Id { get; set; }

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