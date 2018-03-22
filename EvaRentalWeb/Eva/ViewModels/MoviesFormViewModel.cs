using Eva.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eva.ViewModels
{
    public class MoviesFormViewModel
    {

        public IEnumerable<GenreTypes> GenreTypes { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre Types")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "The Release Date field is required")]
        [Display(Name = "Date of Release")]
        public DateTime? ReleasedDate { get; set; }

        [Required(ErrorMessage = "The Number in STock field is required")]
        [Range(1, 200)]
        [Display(Name = "Avalability")]
        public byte? NumberInStock { get; set; }
        public string Title
        {
            get { return (Id != 0) ? "Edit Movie" : "New Movie"; }
        }

        public MoviesFormViewModel()
        {
            Id = 0;
        }

        public MoviesFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }


    }
}