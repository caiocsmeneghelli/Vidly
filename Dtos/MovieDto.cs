using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The must have less than 100 characters.")]
        public string Name { get; set; }

        public DateTime ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20, ErrorMessage = "Please enter a value between 1 and 20.")]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
        public GenreDto Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}