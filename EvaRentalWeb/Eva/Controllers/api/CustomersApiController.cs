using Eva.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Eva.Controllers.api
{
    public class CustomersApiController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersApiController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }


        //GET /api/Customers/id

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }


        //POST /api/Customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //PUT /api/Customers/id
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        //DELETE /api/Customers/id
        [HttpDelete ]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
