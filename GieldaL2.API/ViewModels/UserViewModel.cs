using System.Collections.Generic;

namespace GieldaL2.API.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string EMail { get; set; }
        public decimal Value { get; set; }
    }
}