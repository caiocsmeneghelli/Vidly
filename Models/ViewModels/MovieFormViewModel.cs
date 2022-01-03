using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable Genre { get; set; }
        public int? Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The must have less than 100 characters.")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleasedDate { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "Please enter a value between 1 and 20.")]
        public byte? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public MovieFormViewModel()
        {

        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            DateAdded = movie.DateAdded;
            ReleasedDate = movie.ReleasedDate;
            GenreId = movie.GenreId;
        }
    }
}