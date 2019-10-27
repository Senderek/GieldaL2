using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.DB.Entities
{
    public class Transaction
    {
        public int ID { get; set; }
        public virtual int Buyer_UAT_ID { get; set; }
        public virtual int Seller_UAT_ID { get; set; }
        public virtual int STK_ID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}
