using System;
using System.ComponentModel.DataAnnotations;

namespace Eva.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public GenreTypes Genre { get; set; }

        [Required]
        [Display(Name = "Genre Types")]
        public byte GenreId { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Date of Release")]
        public DateTime ReleasedDate { get; set; }

        [Required]
        [Display(Name = "Avalability")]
        public byte NumberInStock { get; set; }
    }
}