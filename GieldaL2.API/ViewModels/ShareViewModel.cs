namespace GieldaL2.API.ViewModels
{
    public class ShareViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string TotalVolume { get; set; }
        public decimal BuyoutPrice { get; set; }
        public UserViewModel Owner { get; set; }
    }
}