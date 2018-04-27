using Eva.Dtos;
using Eva.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Eva.Controllers.api
{
    public class NewRentalsApiController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsApiController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto NewRental)
        {
            if (NewRental.MovieIds.Count == 0)
                return BadRequest("No movie Ids have been given");
            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == NewRental.CustomerId);

            if (customer == null)
                return BadRequest("Custoemr Id is not valid");
            var movies = _context.Movies.Where(
                m => NewRental.MovieIds.Contains(m.Id)).ToList();
            if (NewRental.MovieIds.Count != movies.Count)
                return BadRequest("One or more movies id are not valid");

            foreach (var movie in movies)
            {
                if (movie.NumberOfAvailability == 0)
                    return BadRequest("");
                movie.NumberOfAvailability--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    RentalTime = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}
