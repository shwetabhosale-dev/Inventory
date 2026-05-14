using System.ComponentModel.DataAnnotations;

namespace Inventory.ViewModel.InvoiceViewModel
{
    public class InvoiceTypeListViewModel
    {
        public int InvoiceTypeId { get; set; }

        [Required]
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
    }
}
