using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FourBugs.Models;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FourBugs.Controllers
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
            bool investor = true;

            if (investor)
            {
                List<Company> companyList = new List<Company>();
                List<Bid> bidList = new List<Bid>();

                Company company1 = new Company(1, "Tech Company", 3, "/images/business1.jpg", "Company specializing in AI technologies");
                Company company2 = new Company(2, "Money Company", 4, "/images/business2.jpg", "Specializing in cloud technologies, our aim is to reach the moon. And beat elon musk to mars");
                Company company3 = new Company(3, "Music Company", 4, "/images/business3.jpg", "Specializing in music, bringing music around the world");

                companyList.Add(company1);
                companyList.Add(company2);
                companyList.Add(company3);

                Bid bid1 = new Bid(1, "Alcohol Company", 100000, true);
                Bid bid2 = new Bid(2, "Farm Company", 500000, null);
                Bid bid3 = new Bid(3, "Data Company", 750000, false);

                bidList.Add(bid1);
                bidList.Add(bid2);
                bidList.Add(bid3);



                ViewData["Recommended"] = companyList;
                ViewData["Bids"] = bidList;

                return View();
            }
            else
            {
                List<Resource> resourceList = new List<Resource>();
                List<Bid> receivedBids = new List<Bid>();

                Resource res1 = new Resource(1, "Business Grants Portal", "/images/businessGrantPortal.jpg", "https://www.businessgrants.gov.sg/", "Business Grants Portal brings government grants for businesses into one place, so it’s easier to find and apply for the grants you need.");
                Resource res2 = new Resource(1, "IMDA", "/images/imda.png", "https://www.imda.gov.sg/programme-listing/smes-go-digital", "The SMEs Go Digital programme aims to help SMEs use digital technologies and build stronger digital capabilities to seize growth opportunities in the digital economy. Building on the foundation of Enhanced iSPRINT, SMEs Go Digital has a more structured and inclusive approach towards the adoption of digital technologies by SMEs.");
                Resource res3 = new Resource(1, "Enterprise Singapore", "/images/enterpriseSG.jpg", "https://www.enterprisesg.gov.sg/", "Enterprise Singapore is the government agency championing enterprise development. We work with committed companies to build capabilities, innovate and internationalise. We also support the growth of Singapore as a hub for global trading and startups. As the national standards and accreditation body, we continue to build trust in Singapore’s products and services through quality and standards.");

                resourceList.Add(res1);
                resourceList.Add(res2);
                resourceList.Add(res3);

                Bid bid1 = new Bid(1, "John", 100000, 30);
                Bid bid2 = new Bid(2, "Warren", 500000, 5);
                Bid bid3 = new Bid(3, "Bill", 750000, 10);

                receivedBids.Add(bid1);
                receivedBids.Add(bid2);
                receivedBids.Add(bid3);

                ViewData["Resources"] = resourceList;
                ViewData["ReceivedBids"] = receivedBids;

                return View();
            }
        }

        public async Task<IActionResult> ConfirmBid(int? id)
        {
            Bid currentBid = new Bid(1, "WineCompany", 100000, 30, "John");
            return View(currentBid);
        }

        public JsonResult SubmitConfirmBid(int id)
        {
            return Json(new { Url = "Index/Home" });
        }

        public int TopUpAccount(int id, int amount)
        {
            return 1;
        }

        public IActionResult CompanyList()
        {
            List<Company> companyList = new List<Company>();

            Company company1 = new Company(1, "Tech Company", 3, "/images/business1.jpg", "Company specializing in AI technologies");
            Company company2 = new Company(2, "Money Company", 4, "/images/business2.jpg", "Specializing in cloud technologies, our aim is to reach the moon. And beat elon musk to mars");
            Company company3 = new Company(3, "Music Company", 4, "/images/business3.jpg", "Specializing in music, bringing music around the world");

            companyList.Add(company1);
            companyList.Add(company2);
            companyList.Add(company3);

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
