using Inventory.Models;

namespace Inventory.ViewModel.SalesViewModel
{
    public class SalesTypeListViewModel
    {
        public int SalesTypeId { get; set; }
        public string SalesTypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public SalesTypeListViewModel()
        {
        }

        public SalesTypeListViewModel(SalesType salesType)
        {
            SalesTypeId = salesType.SalesTypeId;
            SalesTypeName = salesType.SalesTypeName;
            Description = salesType.Description;
        }
    }
}
