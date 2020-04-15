using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyContext vidlyContext;

        public MoviesController()
        {
            vidlyContext = new VidlyContext();
        }
        // GET specific movie
        public ActionResult Detail(int id)
        {
            var movies = vidlyContext.Movies.FirstOrDefault(x => x.Id == id);
            return View(movies);
        }

        // get all movies
        public ActionResult Movies()
        {

            var movies = vidlyContext.Movies.Include(X => X.Genres).ToList();
            return View(movies);
        }

        //new movie registration page
        public ActionResult NewMovie()
        {
            var list = vidlyContext.Genres.ToList();
            var viewmodel = new NewMovieViewModel()
            {Movie= new Movie(),
                Genres = list
            };

            return View("save",viewmodel);
            
        }

        //Database saving and editing a movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new NewMovieViewModel()
                {
                    Movie = movie,
                    Genres = vidlyContext.Genres.ToList()
                };

                return View("Save", viewmodel);
            }

            if(movie.Id==0)
            {
                vidlyContext.Movies.Add(movie);
                vidlyContext.SaveChanges();
                return RedirectToAction("detail", new { id = movie.Id });
            }
            else
            {
                var movieupdate = vidlyContext.Movies.First(x => x.Id == movie.Id);
                movieupdate.Name = movie.Name;
                movieupdate.Loaddate = movie.Loaddate;
                movieupdate.NumberInStock = movie.NumberInStock;
                movieupdate.GenreId = movie.GenreId;
                movieupdate.ReleaseDate = movie.ReleaseDate;
                vidlyContext.SaveChanges();
                return RedirectToAction("detail", new { id = movie.Id });

            }
           
        }

        //edit movie
        public ActionResult Edit(int id)
        {
            var movie = vidlyContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = vidlyContext.Genres.ToList()
                
            };
            return View("save", viewmodel);

        }


    }
}