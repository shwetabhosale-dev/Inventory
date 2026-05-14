using Inventory.Repository.Paging;
using Inventory.ViewModel.InvoiceViewModel;

namespace Inventory.Repository.InvoiceService
{
    public interface IInvoiceRepo
    {
        Task<PaginatedList<InvoiceListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}
