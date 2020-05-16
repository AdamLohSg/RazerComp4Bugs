using System;
using System.Collections.Generic;
using System.Text;
using FourBugs.Model;
using FourBugs.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FourBugs.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Bid> Bid { get; set; }
    }
}
