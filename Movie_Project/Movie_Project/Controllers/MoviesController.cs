using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movie_Project.ViewModel;
using System.Data.Entity.Validation;

namespace Movie_Project.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();

            //return View(movies);
            return View();
        }

        public ActionResult New()
        {
            var Genres = _context.Genres.ToList();

            var viewmodel = new MovieFormViewModel
            {
                Genre = Genres
            };
            return View("MovieForm", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movies)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            movies.DateAdded = DateTime.Now;

            if (movies.Id == 0)
                _context.Movies.Add(movies);
            
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movies.Id);

                movieInDb.Name = movies.Name;
                movieInDb.ReleaseDate = movies.ReleaseDate;
                movieInDb.GenreId = movies.GenreId;
                movieInDb.NumberInStock = movies.NumberInStock;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
           
            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
           
            var viewmodel = new MovieFormViewModel(movie)
            {
                 Genre = _context.Genres.ToList()
            };

            return View("MovieForm", viewmodel);   
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }
    }
}