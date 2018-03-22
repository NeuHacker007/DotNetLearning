using Eva.CustomerValidations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eva.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Must Select one membership type")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        //[Required(ErrorMessage = "Please enter your Date of Birth")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }


    }
}