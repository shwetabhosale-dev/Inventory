using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class PurchaseType
    {
        public int PurchaseTypeId { get; set; }

        [Required]
        public string PurchaseTypeName { get; set; }
        public string Description { get; set; }
    }
}
