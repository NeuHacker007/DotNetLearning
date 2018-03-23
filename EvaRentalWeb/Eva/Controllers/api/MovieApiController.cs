using System.Collections.Generic;
using System.Linq;
using Eva.Models;
using System.Web.Http;

namespace Eva.Controllers.api
{
    public class MovieApiController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieApiController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Moives
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }
    }
}
