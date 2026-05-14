using System.ComponentModel.DataAnnotations;

namespace Inventory.ViewModel.BillViewModel
{
    public class BillTypeListViewModel
    {
        public int BillTypeId { get; set; }

        [Required]
        public string BillTypeName { get; set; }
        public string Description { get; set; }
    }
}
