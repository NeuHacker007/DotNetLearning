using Eva.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Eva.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(
                c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

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