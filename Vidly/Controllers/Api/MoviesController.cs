using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Movies
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        // GET: api/Movies/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST: api/Movies
        [HttpPost]
        public IHttpActionResult Post(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.AddedDate = DateTime.Now;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Ok(movieDto);
        }

        // PUT: api/Movies/5
        [HttpPut]
        public IHttpActionResult Put(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid || movieDto.Id != id)
                return BadRequest();

            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);


            if (movie == null)
                return NotFound();

            movie.AddedDate = DateTime.Now;
            Mapper.Map(movieDto, movie);
            _context.SaveChanges();

            return Ok(movieDto);
        }

        // DELETE: api/Movies/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok("Deleted Successfull");
        }
    }
}
