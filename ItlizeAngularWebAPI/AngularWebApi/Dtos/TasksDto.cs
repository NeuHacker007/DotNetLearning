using System;
using System.ComponentModel.DataAnnotations;

namespace AngularWebApi.Dtos
{
    public class TasksDto
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string QuoteType { get; set; }
        [Required]
        public int QuoteNumber { get; set; }

        [StringLength(maximumLength: 4000)]
        [Required]
        public string Contact { get; set; }

        [StringLength(maximumLength: 4000)]
        [Required]
        public string Task { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [StringLength(50)]
        [Required]
        public string TaskType { get; set; }

        [StringLength(50)]
        [Required]
        public string Status { get; set; }

        [StringLength(maximumLength: 4000)]
        [Required]
        public string Quote { get; set; }
    }
}