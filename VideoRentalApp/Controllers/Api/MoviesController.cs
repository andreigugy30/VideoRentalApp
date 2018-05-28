using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalApp.Dtos;
using VideoRentalApp.Models;

namespace VideoRentalApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
                _dbContext = new ApplicationDbContext();
        }

        //GET api/movies

        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _dbContext.Movies
                .Include(g => g.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return movies;
        }

        //GET api/movies/1

        public IHttpActionResult GetMovies(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            }
        }

        //POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //PUT api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _dbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)

                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, movieInDb);
            _dbContext.SaveChanges();

        }

        //DELETE api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _dbContext.Movies.Remove(movieInDb);
                _dbContext.SaveChanges();
            }
        }
    }
}
