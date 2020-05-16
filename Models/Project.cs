using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourBugs.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumBids { get; set; }
        public string Image { get; set; }
        public string CompanyName { get; set; }

        public Project(int Id, string Name, int NumBids, string Image, string CompanyName)
        {
            this.Id = Id;
            this.Name = Name;
            this.NumBids = NumBids;
            this.Image = Image;
            this.CompanyName = CompanyName;
        }
    }
}
