using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels.Edit
{
    public class EditStockViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Abbreviation { get; set; }
    }
}