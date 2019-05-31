/*-----------------------------------------------------------------
 *   Domain Name:     Ivan_Zhang
 *   Namespace:       EmployeeManagement.DataAccess.Models     
 *   Machine Name:    IVAN_ZHANG
 *   Project Name:    $projectname$
 *   Description:     <Description>
 *   Author:          Ivan                    Date: <5/30/2019 9:37:32 PM>
 *   Notes:           <Notes>
 *   Revision History:
 *   Name:           Date:          Description:
 *-----------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.DataAccess.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string EmployeeName { get; set; }
        [Required]
        [RegularExpression(@"‎^\w+@+?\.$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        [Required]
        public Department? Department { get; set; }

    }
}
