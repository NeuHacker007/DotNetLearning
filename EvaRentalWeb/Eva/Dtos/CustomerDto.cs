using System;
using System.ComponentModel.DataAnnotations;

namespace Eva.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }



        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}