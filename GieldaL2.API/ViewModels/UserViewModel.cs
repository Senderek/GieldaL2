using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DefaultValue(0)]
        public decimal Value { get; set; }
    }
}
