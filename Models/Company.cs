using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FourBugs.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uen { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int NumBids { get; set; }


        public Company(int Id, string Name, int NumBids, string ImageUrl, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.NumBids = NumBids;
            this.ImageUrl = ImageUrl;
            this.Description = Description;
        }

        public Company(int Id, string Name, string Uen, string Description, string ImageUrl)
        {
            this.Id = Id;
            this.Name = Name;
            this.Uen = Uen;
            this.Description = Description;
            this.ImageUrl = ImageUrl;
        }
    }
}
