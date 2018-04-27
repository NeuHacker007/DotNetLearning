using AutoMapper;
using Eva.Dtos;
using Eva.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public IHttpActionResult GetMovies(string query = null)
        {

            var movieQuery = _context.Movies.Include(m => m.Genre)
                .Where(m => m.NumberOfAvailability > 0);

            if (!string.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));

            //var moviesDto = _context.Movies.Include(m => m.Genre)
            //    .ToList()
            //    .Select(Mapper.Map<Movie, MovieDto>);

            var moviesDto = movieQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesDto);
        }

        // GET /api/Movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                NotFound();


            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/Movies
        [HttpPost]
        [Authorize(Roles = RolesName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        //PUT /api/movie/id

        [HttpPut]
        [Authorize(Roles = RolesName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                NotFound();

            var movie = Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();

        }


        //DELETE /api/movies/id
        [HttpDelete]
        [Authorize(Roles = RolesName.CanManageMovies)]
        public IHttpActionResult DELETE(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();

        }
    }
}
