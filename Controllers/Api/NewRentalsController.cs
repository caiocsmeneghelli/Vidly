﻿using System;
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
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(
                m => newRental.MoviesId.Contains(m.Id));

            foreach (var movie in movies)
            {
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