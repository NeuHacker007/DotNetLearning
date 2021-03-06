﻿using System;
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

        [Required]
        [StringLength(50)]
        public string TaskType { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [StringLength(maximumLength: 4000)]
        public string Quote { get; set; }
    }
}