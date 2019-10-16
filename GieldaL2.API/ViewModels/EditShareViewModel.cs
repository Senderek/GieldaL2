using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels
{
    public class EditShareViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Abbreviation { get; set; }

        [DefaultValue(0)]
        public string TotalVolume { get; set; }

        [DefaultValue(0)]
        public decimal BuyoutPrice { get; set; }
    }
}