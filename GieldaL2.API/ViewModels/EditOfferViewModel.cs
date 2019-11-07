using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels
{
    public class EditOfferViewModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ShareId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Value { get; set; }
    }
}