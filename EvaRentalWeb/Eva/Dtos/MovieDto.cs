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

        [Required]
        public byte GenreId { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime ReleasedDate { get; set; }

        [Required]
        [Range(1, 200)]
        public byte NumberInStock { get; set; }
    }
}