using Inventory.Models;
using System.ComponentModel.DataAnnotations;

namespace Inventory.ViewModel.BillViewModel
{
    public class BillTypeListViewModel
    {
        public int BillTypeId { get; set; }

        [Required]
        public string BillTypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public BillTypeListViewModel()
        {
        }

        public BillTypeListViewModel(BillType billType)
        {
            BillTypeId = billType.BillTypeId;
            BillTypeName = billType.BillTypeName;
            Description = billType.Description;
        }
    }
}
