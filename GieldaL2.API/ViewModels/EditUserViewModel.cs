using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string EMail { get; set; }

        [Required]
        public decimal Value { get; set; }
    }
}
