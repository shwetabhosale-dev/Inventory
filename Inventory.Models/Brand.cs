using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
