using System;
using System.ComponentModel.DataAnnotations;

namespace Eva.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public DateTime RentalTime { get; set; }

        public DateTime? ReturnTime { get; set; }
    }
}