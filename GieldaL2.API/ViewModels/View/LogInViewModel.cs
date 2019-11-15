using System.ComponentModel.DataAnnotations;

namespace GieldaL2.API.ViewModels.View
{
    public class LogInViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
