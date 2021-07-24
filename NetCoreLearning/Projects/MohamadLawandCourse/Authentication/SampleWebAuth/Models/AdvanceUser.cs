using Microsoft.AspNetCore.Identity;

namespace SampleWebAuth.Models
{
    public class AdvanceUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
    }
}