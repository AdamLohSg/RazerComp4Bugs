using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourBugs.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BidPrice { get; set; }
        public bool? Status { get; set; }
        public int EquityOffered { get; set; }
        public string CompanyName { get; set; }



        public Bid(int Id, string Name, int BidPrice, bool? Status)
        {
            this.Id = Id;
            this.Name = Name;
            this.BidPrice = BidPrice;
            this.Status = Status;
        }

        public Bid(int Id, string Name, int BidPrice, int EquityOffered)
        {
            this.Id = Id;
            this.Name = Name;
            this.BidPrice = BidPrice;
            this.EquityOffered = EquityOffered;
        }

        public Bid(int Id, string CompanyName, int BidPrice, int EquityOffered, string BidderName)
        {
            this.Id = Id;
            this.Name = BidderName;
            this.BidPrice = BidPrice;
            this.EquityOffered = EquityOffered;
            this.CompanyName = CompanyName;
        }
    }
}
