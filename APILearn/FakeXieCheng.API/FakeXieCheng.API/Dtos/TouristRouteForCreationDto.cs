using FakeXieCheng.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeXieCheng.API.Dtos
{
    public class TouristRouteForCreationDto : TouristRouteForManipulationDto //: IValidatableObject
    {
      

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
