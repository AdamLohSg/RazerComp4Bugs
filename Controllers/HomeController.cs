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
using Microsoft.AspNetCore.Mvc.Diagnostics;

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

                ViewData["Resources"] = _context.Resources.ToList();
                ViewData["ReceivedBids"] = _context.Bid.Where(s => s.BidderId == user.Id).ToList();
                ViewData["CurrentBalance"] = MambuController.getBalance(user.SavingsAccountID);


                return View();
            }
        }

        public async Task<IActionResult> ConfirmBid(int? id)
        {
            Bid currentBid = _context.Bid.Where(b => b.Id == id).First();
            return View();
        }

        public JsonResult SubmitConfirmBid(int id, int companyId)
        {
            Bid currentBid = _context.Bid.Where(b => b.Id == id).First();
            currentBid.Status = "Accepted";
            _context.Bid.Update(currentBid);
            _context.SaveChanges();

            List<Bid> bidList = _context.Bid.Where(b => b.Id != id && b.CompanyId == companyId).ToList<Bid>();
            foreach(var b in bidList)
            {
                b.Status = "Rejected";
                _context.Bid.Update(b);
            }
            _context.SaveChanges();
            return Json(new { Url = "Index/Home" });
        }

        public async Task<int> TopUpAccountAsync(int id, int amount)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            MambuController.deposit(user.SavingsAccountID, amount);

            return 1;
        }

        public async Task<IActionResult> CompanyList()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companies = from c in _context.Company
                            select c;
            List<Company> companyList = companies.ToList<Company>();
            foreach (var c in companyList)
            {
                c.NumBids = _context.Bid.Where(b => b.CompanyId == c.Id).Count();
            }

            List<Bid> bidList = _context.Bid.Where(b => b.BidderId == user.Id).ToList<Bid>();

            foreach(var b in bidList)
            {
                companyList.RemoveAll(x => x.Id == b.CompanyId);
            }

            ViewData["Companies"] = companyList;

            return View();
        }

        public async Task<int> SubmitBid(string companyName, string amount, string equity)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            int companyId = _context.Company.Where(c => c.Name == companyName).Select(c => c.Id).First();
            Bid b = new Bid(user.Id, Convert.ToInt32(amount), Convert.ToInt32(equity), companyId, "Pending");
            _context.Bid.Add(b);
            _context.SaveChanges();

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
