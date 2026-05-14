using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class BillType
    {
        public int BillTypeId { get; set; }

        [Required]
        public string BillTypeName { get; set; }
        public string Description { get; set; }

    }
}
