using CRM_Project.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Project.Controllers
{
    public class DashboardController : Controller
    {
        private AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.CustomerCount = _context.Customers.Count();
            ViewBag.PolicyCount = _context.Policies.Count();
            ViewBag.RecentLogs = _context.ContactLogs.Include(c => c.Customer).OrderByDescending(l => l.ContactDate).Take(5).ToList();
            ViewBag.LastCustomer = _context.Customers.OrderByDescending(c => c.CreationTime).FirstOrDefault();
            return View();
        }
    }
}
