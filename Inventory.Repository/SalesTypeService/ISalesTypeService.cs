using Inventory.Repository.Paging;
using Inventory.ViewModel.SalesViewModel;

namespace Inventory.Repository.SalesTypeService
{
    public interface ISalesTypeService
    {
        Task<PaginatedList<SalesTypeListViewModel>> GetAll(int pageNumber, int pageSize);

        Task Add(SalesTypeListViewModel viewModel);

        Task Update(SalesTypeListViewModel viewModel);

        Task Delete(int SalesTypeId);

        Task<SalesTypeListViewModel> GetById(int salesTypeId);

        Task AddByStoredProcedure(SalesTypeListViewModel viewModel);
    }
}
