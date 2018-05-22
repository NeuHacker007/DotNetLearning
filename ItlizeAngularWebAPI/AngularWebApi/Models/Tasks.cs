using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AngularWebApi.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string QuoteType { get; set; }
        public int QuoteNumber { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Contact { get; set; }

        [StringLength(maximumLength: 4000)]
        public string Task { get; set; }

        public DateTime DueDate { get; set; }
        [StringLength(50)]
        public string TaskType { get; set; }
    }
}