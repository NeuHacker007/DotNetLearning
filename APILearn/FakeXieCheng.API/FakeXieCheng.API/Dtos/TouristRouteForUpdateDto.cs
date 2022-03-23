using FakeXieCheng.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeXieCheng.API.Dtos
{
    
    public class TouristRouteForUpdateDto : TouristRouteForManipulationDto
    {
        
        [Required(ErrorMessage = "更新必备")]
        [MaxLength(1500)]
        /*
         调用使用new来处理的方法，子类的引用调用执行子类的方法，基类的引用调用执行基类的方法。
         而对于使用override修饰的方法来说，不管是子类还是基类都只会执行子类的方法。
         
         */
        public override string Description { get; set; }

       
    }
}
