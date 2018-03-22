using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eva.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public GenreTypes Genre { get; set;}

        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime ReleasedDate { get; set; }
        public byte NumberInStock { get; set; }
    }
}