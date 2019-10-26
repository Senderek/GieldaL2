using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Entities
{
    public class Offer
    {
        public int ID { get; set; }
        public virtual int SUR_ID { get; set; }
        public int Amount { get; set; }
        public double Value { get; set; }
        public char Type { get; set; }
        public DateTime Date { get; set; }
    }
}
