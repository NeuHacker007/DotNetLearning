using System.ComponentModel.DataAnnotations;

namespace Eva.Models
{
    public class GenreTypes
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}