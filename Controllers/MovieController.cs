using Mosh.Models;
using Mosh.ViewsModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mosh.Controllers
{
    public class MovieController : Controller
    {
        private RecordContext db = new RecordContext();
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = db.Movies.Include(m =>m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = db.Genres.ToList(),
 
            };
            return View("MovieForm",viewModel);
        }


        public ActionResult Edit(int id)
        {
            var movie = db.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var genres = db.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = db.Genres.ToList()
                }; 

                return View("MovieForm", viewModel);
            }

            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                db.Movies.Add(movie);
            }
            else
            {
                var movieInDb = db.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Random()
        {
            //To learn View Models

            var movie = new Movie() { Name = "Shrek" };


            var customers = new List<Customer>
            {
                new Customer { Name = "Customer_1" },
                new Customer { Name = "Customer_2" }
            };

            var ViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(ViewModel);
        }



        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie { Id = 1, Name = "Shrek" },
        //        new Movie { Id = 2, Name = "Wall-e" }
        //    };
        //}


        //public ActionResult Index(int? PageIndex, string SortBy)
        //{
        //    if (!PageIndex.HasValue)
        //        PageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(SortBy))
        //        SortBy = "Name";

        //    return Content(String.Format("Page Index: {0} & SortBy: {1}", PageIndex, SortBy));
        //}



        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{

        //    return Content(year + "/" + month);
        //}


    }
}