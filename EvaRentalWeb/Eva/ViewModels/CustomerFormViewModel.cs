using Eva.CustomerValidations;
using Eva.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eva.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        [Required(ErrorMessage = "Must Select one membership type")]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }

        //[Required(ErrorMessage = "Please enter your Date of Birth")]
        [Display(Name = "Date of Birth")]

        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        public String Title
        {
            get { return Id != 0 ? "Edit Customer" : "New Customer"; }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            MembershipTypeId = customer.MembershipTypeId;
            BirthDate = customer.BirthDate;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        }
    }
}