using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels.Edit
{
    public class EditShareViewModel
    {
        [Required]
        public int StockId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}