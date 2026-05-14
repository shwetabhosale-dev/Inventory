using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class InvoiceType
    {
        public int InvoiceTypeId { get; set; }

        [Required]
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
    }
}
