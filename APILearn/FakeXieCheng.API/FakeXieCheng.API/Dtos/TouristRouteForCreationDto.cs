using FakeXieCheng.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeXieCheng.API.Dtos
{
    [TouristRouteTitleMustBeDifferentFromDescription]
    public class TouristRouteForCreationDto //: IValidatableObject
    {
        [Required(ErrorMessage = "Title 不可为空")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description 不可为空")]
        [MaxLength(1500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        //public decimal OriginalPrice { get; set; }

        //public double? DiscountPresent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public string Features { get; set; }

        public string Fees { get; set; }

        public string Notes { get; set; }

        public double? Rating { get; set; }
        public string TravelDays { get; set; }

        public string TripType { get; set; }

        public string DepartureCity { get; set; }

        public ICollection<TouristRoutePictureForCreationDto> TouristRoutePictures { get; set; }
                            = new List<TouristRoutePictureForCreationDto>();

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //    {
        //        yield return new ValidationResult (
        //            "路线名称必须与路线描述不同",
        //            new[] { "TouristRoutePictureForCreationDto"}
                    
        //            );
        //    }
        //}
    }
}
