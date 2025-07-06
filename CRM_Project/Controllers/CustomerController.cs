using CRM_Project.Context;
using CRM_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Project.Controllers
{
    public class CustomerController : Controller
    {
        private AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            var CustomerToDelete = _context.Customers.Find(customer.Id);

            if (CustomerToDelete == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(CustomerToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
