using CRM_Project.Context;
using CRM_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRM_Project.Controllers
{
    public class PolicyController : Controller
    {
        private AppDbContext _context;

        public PolicyController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var policies = _context.Policies.Include(p => p.Customer).ToList();
            return View(policies);
        }
        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(_context.Customers, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Policy policy)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Customers = new SelectList(_context.Customers, "Id", "FullName");
                return View(policy);
            }

            _context.Policies.Add(policy);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var policy = _context.Policies.Find(id);

            if (policy == null)
            {
                return NotFound();
            }

            ViewBag.Customers = new SelectList(_context.Customers, "Id", "FullName",policy.CustomerId);
            return View(policy);
        }
        [HttpPost]
        public IActionResult Edit(Policy policy)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Customers = new SelectList(_context.Customers, "Id", "FullName", policy.CustomerId);
                return View(policy);
            }

            _context.Policies.Update(policy);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }      
        public IActionResult Delete(int id)
        {
            var policy = _context.Policies.Include(p=>p.Customer).FirstOrDefault(p=>p.Id == id);

            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }
        [HttpPost]
        public IActionResult Delete(Policy policy)
        {
            if (policy == null)
            {
                return NotFound();
            }

            _context.Policies.Remove(policy);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
