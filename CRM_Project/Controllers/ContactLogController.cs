using CRM_Project.Context;
using CRM_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRM_Project.Controllers
{
    public class ContactLogController : Controller
    {
        private AppDbContext _context;

        public ContactLogController(AppDbContext context)
        {
            _context = context;   
        }

        public IActionResult Index()
        {
            var logs = _context.ContactLogs.Include(l=>l.Customer).ToList();
            return View(logs);
        }

        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(_context.Customers,"Id","FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactLog log)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Customers = new SelectList(_context.Customers, "Id", "FullName");
                return View(log);
            }

            _context.ContactLogs.Add(log);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var log = _context.ContactLogs.Find(id);

            if (log == null)
            {
                return NotFound();
            }

            ViewBag.Customers = new SelectList(_context.Customers, "Id", "FullName", log.CustomerId);
            return View(log);
        }

        [HttpPost]
        public IActionResult Edit(ContactLog log)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Customers = new SelectList(_context.Customers, "Id", "FullName", log.CustomerId);
                return View(log);
            }

            _context.ContactLogs.Update(log);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var log = _context.ContactLogs.Include(l=> l.Customer).FirstOrDefault(l => l.Id == id);

            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        [HttpPost]
        public IActionResult Delete(ContactLog log)
        {
            if (log == null)
            {
                return NotFound();
            }

            _context.ContactLogs.Remove(log);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
