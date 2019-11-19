namespace GieldaL2.INFRASTRUCTURE.DTO
{
    /// <summary>
    /// Data Transfer Object that sotres information of transaction
    /// </summary>
    public class TransactionDTO
    {
        /// <summary>
        /// Identifier of transaction
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identifier of user that bought Stock
        /// </summary>
        public int BuyerId { get; set; }
        /// <summary>
        /// Identifier fo user that sold Stock 
        /// </summary>
        public int SellerId { get; set; }
        /// <summary>
        /// Identifier of stock that was object of transaction
        /// </summary>
        public int StockId { get; set; }
        /// <summary>
        /// Amount of stocks that changed owner
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Price paid per share
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Date when transaction happened
        /// </summary>
        public DateTime Date { get; set; }
    }
}
