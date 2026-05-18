using Inventory.Models;
using System.ComponentModel.DataAnnotations;

namespace Inventory.ViewModel.InvoiceViewModel
{
    public class InvoiceTypeListViewModel
    {
        public int InvoiceTypeId { get; set; }

        [Required]
        public string InvoiceTypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public InvoiceTypeListViewModel()
        {
            
        }

        public InvoiceTypeListViewModel(InvoiceType invoiceType)
        {
            InvoiceTypeId = invoiceType.InvoiceTypeId;
            InvoiceTypeName = invoiceType.InvoiceTypeName;
            Description = invoiceType.Description;
        }
    }
}
