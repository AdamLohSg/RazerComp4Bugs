using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FourBugs.Models;
using System.Runtime.InteropServices.WindowsRuntime;
using _4Bugs.Controllers;
using Microsoft.AspNetCore.Identity;
using FourBugs.Data;
using FourBugs.Model;

namespace FourBugs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
                Response.Redirect("/Identity/Account/login");

            bool investor = true;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (investor)
            {

                var companies = from c in _context.Company
                                select c;
                List<Company> companyList = companies.ToList<Company>();

                List<Bid> bidList = _context.Bid.Where(b => b.BidderId == user.Id).ToList<Bid>();

                foreach (var b in bidList)
                {
                    b.CompanyName = _context.Company.Where(c => c.Id == b.CompanyId).Select(c => c.Name).FirstOrDefault();
                }



                ViewData["Recommended"] = companyList;
                ViewData["Bids"] = bidList;
                ViewData["CurrentBalance"] = MambuController.getBalance(user.SavingsAccountID);

                return View();
            }
            else
            {
                //List<Resource> resourceList = new List<Resource>();
                //List<Bid> receivedBids = new List<Bid>();

                //Resource res1 = new Resource(1, "Business Grants Portal", "/images/businessGrantPortal.jpg", "https://www.businessgrants.gov.sg/", "Business Grants Portal brings government grants for businesses into one place, so it’s easier to find and apply for the grants you need.");
                //Resource res2 = new Resource(1, "IMDA", "/images/imda.png", "https://www.imda.gov.sg/programme-listing/smes-go-digital", "The SMEs Go Digital programme aims to help SMEs use digital technologies and build stronger digital capabilities to seize growth opportunities in the digital economy. Building on the foundation of Enhanced iSPRINT, SMEs Go Digital has a more structured and inclusive approach towards the adoption of digital technologies by SMEs.");
                //Resource res3 = new Resource(1, "Enterprise Singapore", "/images/enterpriseSG.jpg", "https://www.enterprisesg.gov.sg/", "Enterprise Singapore is the government agency championing enterprise development. We work with committed companies to build capabilities, innovate and internationalise. We also support the growth of Singapore as a hub for global trading and startups. As the national standards and accreditation body, we continue to build trust in Singapore’s products and services through quality and standards.");

                //resourceList.Add(res1);
                //resourceList.Add(res2);
                //resourceList.Add(res3);

                //Bid bid1 = new Bid(1, "John", 100000, 30);
                //Bid bid2 = new Bid(2, "Warren", 500000, 5);
                //Bid bid3 = new Bid(3, "Bill", 750000, 10);

                //receivedBids.Add(bid1);
                //receivedBids.Add(bid2);
                //receivedBids.Add(bid3);

                ViewData["Resources"] = resourceList;
                ViewData["ReceivedBids"] = receivedBids;
                ViewData["CurrentBalance"] = MambuController.getBalance(user.SavingsAccountID);


                return View();
            }
        }

        public async Task<IActionResult> ConfirmBid(int? id)
        {
            //Bid currentBid = new Bid(1, "WineCompany", 100000, 30, "John");
            return View(currentBid);
        }

        public JsonResult SubmitConfirmBid(int id)
        {
            return Json(new { Url = "Index/Home" });
        }

        public async Task<int> TopUpAccountAsync(int id, int amount)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            MambuController.deposit(user.SavingsAccountID, amount);

            return 1;
        }

        public IActionResult CompanyList()
        {

            var companies = from c in _context.Company
                            select c;
            List<Company> companyList = companies.ToList<Company>();
            foreach (var c in companyList)
            {
                c.NumBids = _context.Bid.Where(b => b.CompanyId == c.Id).Count();
            }

            ViewData["Companies"] = companyList;

            return View();
        }

        public int SubmitBid(int id, int amount, int equity)
        {
            return 1;
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
