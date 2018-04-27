using System;
using System.ComponentModel.DataAnnotations;

namespace Eva.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        [StringLength(255)]
        public string Name { get; set; }


        public GenreTypes Genre { get; set; }

        [Required]
        [Display(Name = "Genre Types")]
        public byte GenreId { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "The Release Date field is required")]
        [Display(Name = "Date of Release")]
        public DateTime ReleasedDate { get; set; }

        [Required(ErrorMessage = "The Number in STock field is required")]
        [Range(1, 200)]
        [Display(Name = "Avalability")]
        public byte NumberInStock { get; set; }

        public byte NumberOfAvailability { get; set; }
    }
}