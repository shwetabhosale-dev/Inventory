using Inventory.Repository.Paging;
using Inventory.ViewModel.InvoiceViewModel;

namespace Inventory.Repository.InvoiceTypeService
{
    public interface IInvoiceTypeRepo
    {
        Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageNumber, int pageSize);

        Task Add(InvoiceTypeListViewModel viewModel);

        Task Update(InvoiceTypeListViewModel viewModel);

        Task Delete(int InvoiceTypeId);

        Task<InvoiceTypeListViewModel> GetById(int InvoiceTypeId);

        Task AddByStoredProcedure(InvoiceTypeListViewModel viewModel);
    }
}
