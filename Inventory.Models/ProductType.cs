using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }

        [Required]
        public string ProductTypeName { get; set; }
        public string Description { get; set; }
    }
}
