using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The must have less than 100 characters.")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [IfFutureDate]
        public DateTime ReleasedDate { get; set; }

        [Display(Name = "Date Added")]
        [IfFutureDate]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "Please enter a value between 1 and 20.")]
        public byte NumberInStock { get; set; }
        
        public Genre Genre { get; set; }
        
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}