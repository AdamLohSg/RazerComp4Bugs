using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourBugs.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string OrgName { get; set; }
        public string ImgUrl { get; set; }
        public string SiteUrl { get; set; }
        public string Description { get; set; }

        public Resource(int Id, string OrgName, string ImgUrl, string SiteUrl, string Description)
        {
            this.Id = Id;
            this.OrgName = OrgName;
            this.ImgUrl = ImgUrl;
            this.SiteUrl = SiteUrl;
            this.Description = Description;
        }
    }
}
