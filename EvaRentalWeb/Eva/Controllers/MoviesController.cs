using Eva.Models;
using Eva.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Eva.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            if (User.IsInRole(RolesName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return RedirectToAction("Index", "Movies");
            }
            return View(movie);
        }

        [Authorize(Roles = RolesName.CanManageMovies)]
        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MoviesFormViewModel()
            {
                GenreTypes = genreTypes
            };

            return View("MovieForms", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movie)
                {
                    GenreTypes = _context.GenreTypes.ToList()
                };

                return View("MovieForms", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleasedDate = movie.ReleasedDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movieInDb.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


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

        [Authorize(Roles = RolesName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MoviesFormViewModel(movie)
            {
                GenreTypes = _context.GenreTypes.ToList()

            };
            return View("MovieForms", viewModel);
        }

        [Authorize(Roles = RolesName.CanManageMovies)]
        public ActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        [Obsolete]
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content($"pageIndex={pageIndex}&&sortby={sortBy}");
        //}

        [Route(@"movies/released/{year:regex(\d{4})}/{month:regex(\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content($"movies released at {year} - {month}");
        }

        [Obsolete]
        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie() {Id = 1, Name = "Shrek!"},
                new Movie() {Id = 2, Name = "AAAA"}
            };
            return movies;
        }

    }
}