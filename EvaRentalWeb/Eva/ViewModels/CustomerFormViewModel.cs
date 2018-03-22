using Eva.Models;
using System;
using System.Collections.Generic;

namespace Eva.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public String Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return "Edit Customer";
                }

                return "Create Customer";
            }
        }
    }
}