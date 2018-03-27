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
        public IHttpActionResult GetMovies()
        {
            var moviesDto = _context.Movies.Include(m => m.Genre)
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
