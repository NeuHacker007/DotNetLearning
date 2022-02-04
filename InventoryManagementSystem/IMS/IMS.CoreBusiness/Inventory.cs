using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }


    }
}