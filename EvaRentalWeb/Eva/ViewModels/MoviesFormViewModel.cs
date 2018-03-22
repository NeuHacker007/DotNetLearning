using Eva.Models;
using System.Collections.Generic;

namespace Eva.ViewModels
{
    public class MoviesFormViewModel
    {
        public IEnumerable<GenreTypes> GenreTypes { get; set; }
        public Movie Movie { get; set; }

        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                {
                    return "Edit Movie";
                }

                return "New Movie";
            }
        }
    }
}