using Eva.Models;
using Eva.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Eva.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };
            var customers = new List<Customer>()
            {
                new Customer() {Name = "Ivan"},
                new Customer() {Name = "Guopin"}
            };

            var viewModel = new RandomMovieVIewModel
            {
                movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content($"id is {id}");
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"pageIndex={pageIndex}&&sortby={sortBy}");
        }

        [Route(@"movies/released/{year:regex(\d{4})}/{month:regex(\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content($"movies released at {year} - {month}");
        }
    }
}