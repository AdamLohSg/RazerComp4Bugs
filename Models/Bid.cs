using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bugs.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BidPrice { get; set; }
        public bool? Status { get; set; }

        public Bid(int Id, string Name, int BidPrice, bool? Status)
        {
            this.Id = Id;
            this.Name = Name;
            this.BidPrice = BidPrice;
            this.Status = Status;
        }
    }
}
