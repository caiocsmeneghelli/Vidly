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
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var model = new MovieFormViewModel()
            {
                Id = 0,
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm", model);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var model = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(model)
                {
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (model.Id == 0)
                _context.Movies.Add(model);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == model.Id);
                movieInDb.Name = model.Name;
                movieInDb.ReleasedDate = model.ReleasedDate;
                movieInDb.DateAdded = model.DateAdded;
                movieInDb.NumberInStock = model.NumberInStock;
                movieInDb.GenreId = model.GenreId;
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