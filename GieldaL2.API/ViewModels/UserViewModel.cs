using System.Collections.Generic;

namespace GieldaL2.API.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public List<ShareViewModel> Shares { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}