using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MovieController : ApiController
    {
        private VidlyContext _context;
        public MovieController()
        {
            _context = new VidlyContext();

        }

        // get all Movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));

        }
        //get specific movie
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();

            else
            {
                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            }
        }
        //add new movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto moviedto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(moviedto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviedto);

        }

        //edit movie
        [HttpPut]
        public IHttpActionResult EditMovie(int id, MovieDto moviedto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();
            Mapper.Map<MovieDto, Movie>(moviedto, movie);
            _context.SaveChanges();
            return Ok(moviedto);

        }

        //delete customer
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var cust = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (cust == null)
                return NotFound();
            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return Ok();

        }

    }
}

