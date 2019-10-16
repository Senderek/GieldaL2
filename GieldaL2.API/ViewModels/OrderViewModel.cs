namespace GieldaL2.API.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }
        public ShareViewModel Share { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
    }
}