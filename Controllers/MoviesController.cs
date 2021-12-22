using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            var model = new MovieFormViewModel()
            {
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm", model);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var model = new MovieFormViewModel()
            {
                Movie = movie,
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm", model);
        }
        [HttpPost]
        public ActionResult Save(MovieFormViewModel model)
        {
            if (model.Movie.Id == 0)
                _context.Movies.Add(model.Movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == model.Movie.Id);
                movieInDb.Name = model.Movie.Name;
                movieInDb.ReleasedDate = model.Movie.ReleasedDate;
                movieInDb.DateAdded = model.Movie.DateAdded;
                movieInDb.NumberInStock = model.Movie.NumberInStock;
                movieInDb.GenreId = model.Movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
                
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Shrek!" };
            var customers = new List<Customer>() { new Customer() { Id = 4, Name = "Caio Cesar" }, new Customer() { Id = 5, Name = "Customer 2" } };
            var viewModel = new RandomMovieViewModel() { Movie = movie, Customers = customers };
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}