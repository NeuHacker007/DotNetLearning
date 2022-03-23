using FakeXieCheng.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeXieCheng.API.Dtos
{
    
    public class TouristRouteForUpdateDto : TouristRouteForManipulationDto
    {
        
        [Required(ErrorMessage = "Description 不可为空")]
        [MaxLength(1500)]
        public override string Description { get; set; }

       
    }
}
