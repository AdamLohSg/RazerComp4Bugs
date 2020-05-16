using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourBugs.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public string BidderId { get; set; }
        public int BidPrice { get; set; }
        public int EquityOffered { get; set; }
        public int CompanyId { get; set; }
        public string Status { get; set; }
        public string CompanyName { get; set; }



        public Bid(int Id, string BidderId, int BidPrice, int EquityOffered, int CompanyId, string Status)
        {
            this.Id = Id;
            this.BidderId = BidderId;
            this.BidPrice = BidPrice;
            this.EquityOffered = EquityOffered;
            this.CompanyId = CompanyId;
            this.Status = Status;
        }

        public Bid(string BidderId, int BidPrice, int EquityOffered, int CompanyId, string Status)
        {
            this.BidderId = BidderId;
            this.BidPrice = BidPrice;
            this.EquityOffered = EquityOffered;
            this.CompanyId = CompanyId;
            this.Status = Status;
        }

    }
}
