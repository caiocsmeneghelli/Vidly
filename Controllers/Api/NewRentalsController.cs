using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MoviesId.Count == 0)
                return BadRequest("No movie Ids have been given.");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("CustomerId is not valid");

            var movies = _context.Movies.Where(
                m => newRental.MoviesId.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MoviesId.Count)
                return BadRequest("One or more MoviesIds are invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest(string.Format("Movie {0} is not available.", movie.Name));

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    DateRented = DateTime.Now,
                    Customer = customer,
                    Movie = movie
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
            
        }
    }
}
