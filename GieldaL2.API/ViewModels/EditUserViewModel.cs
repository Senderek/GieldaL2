using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [DefaultValue(0)]
        public decimal Value { get; set; }
    }
}
