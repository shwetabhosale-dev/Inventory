using Inventory.Repository.Paging;
using Inventory.ViewModel.InvoiceViewModel;
using Inventory.ViewModel.Mapping;

namespace Inventory.Repository.InvoiceService
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public InvoiceRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<PaginatedList<InvoiceListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var InvoiceList = _applicationDbContext.Invoices;
            var InvoiceListViewModel = InvoiceList.InvoiceListToInvoiceListViewModel().AsQueryable();
            return await PaginatedList<InvoiceListViewModel>.CreateAsync(InvoiceListViewModel, pageNumber, pageSize);
        }
    }
}
