using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerMembership.Models
{
    [Table("Users")]
    public class tblUser
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserEmailAddress { get; set; }
    }
}