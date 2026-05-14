using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class NumberSequence
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Module { get; set; }

        [Required]
        public string Prefix { get; set; }
        public int LastNumber { get; set; }
    }
}
