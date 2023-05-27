using System.ComponentModel.DataAnnotations;

namespace FarmCentralWeb.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateSupplied { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Type { get; set; }
        [Required]
        public string FarmerId { get; set; }

        [Required]
        public string FarmerName { get; set; }
    }
}
