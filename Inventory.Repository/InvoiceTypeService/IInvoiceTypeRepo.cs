using Inventory.Repository.Paging;
using Inventory.ViewModel.InvoiceViewModel;

namespace Inventory.Repository.InvoiceTypeService
{
    public interface IInvoiceTypeRepo
    {
        Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}
