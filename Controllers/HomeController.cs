using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _4Bugs.Models;

namespace _4Bugs.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Project> projectList = new List<Project>();
            List<Bid> bidList = new List<Bid>();
            
            Project project1 = new Project(1, "Tech Company", 3, "/images/business1.jpg", "Company specializing in AI technologies");
            Project project2 = new Project(2, "Money Company", 4, "/images/business2.jpg", "Specializing in cloud technologies, our aim is to reach the moon. And beat elon musk to mars");
            Project project3 = new Project(3, "Music Company", 4, "/images/business3.jpg", "Specializing in music, bringing music around the world");

            projectList.Add(project1);
            projectList.Add(project2);
            projectList.Add(project3);

            Bid bid1 = new Bid(1, "Alcohol Company", 100000, true);
            Bid bid2 = new Bid(2, "Farm Company", 500000, null);
            Bid bid3 = new Bid(3, "Data Company", 750000, false);

            bidList.Add(bid1);
            bidList.Add(bid2);
            bidList.Add(bid3);



            ViewData["Recommended"] = projectList;
            ViewData["Bids"] = bidList;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
