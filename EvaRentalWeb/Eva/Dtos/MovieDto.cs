using System;
using System.ComponentModel.DataAnnotations;

namespace Eva.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreTypeDto Genre { get; set; }


        public byte GenreId { get; set; }


        public DateTime DateAdded { get; set; }


        public DateTime ReleasedDate { get; set; }


        [Range(1, 200)]
        public byte NumberInStock { get; set; }
    }
}