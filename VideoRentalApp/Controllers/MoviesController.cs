using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Models;
using VideoRentalApp.ViewModels;

namespace VideoRentalApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            //var movies = _dbContext.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(Role.CanManageMovies))
           
                return View("Index");
            
            return View("UserList");
            
            
        }
        [Authorize(Roles = Role.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _dbContext.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = Role.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _dbContext.Genres.ToList()
            };
            
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = Role.CanManageMovies)]
        [HttpPost]
        public ActionResult SaveMovie(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _dbContext.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
               
            }
            _dbContext.SaveChanges();
            TempData["message"] = string.Format("{0} has been saved", movie.Name);
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


    }
}