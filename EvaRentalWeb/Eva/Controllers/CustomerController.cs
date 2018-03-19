using Eva.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Eva.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [Obsolete]
        // GET: Customer
        private List<Customer> GetCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "Ivan"},
                new Customer() {Id = 2, Name = "Guopin"},
                new Customer() {Id = 3, Name = "Eva"}
            };
            return customers;
        }
    }
}