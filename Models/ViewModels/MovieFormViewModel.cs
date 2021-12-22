using System.Collections;

namespace Vidly.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable Genre { get; set; }
        public Movie Movie { get; set; }
    }
}