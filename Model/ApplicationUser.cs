using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourBugs.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string MambuId { get; set; }
        public string SavingsAccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ValidUntil { get; set; }
        public string DocumentID { get; set; }
    }
}
