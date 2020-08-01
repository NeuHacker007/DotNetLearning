
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityframeworkCoreDemo
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }
        [Column("home_phone")]
        public string HomePhone { get; set; }
        [Column("cell_phone")]
        public string CellPhone { get; set; }

    }
}
