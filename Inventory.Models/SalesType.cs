using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class SalesType
    {
        public int SalesTypeId { get; set; }

        [Required]
        public string SalesTypeName { get; set; }
        public string Description { get; set; }
    }
}
