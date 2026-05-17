using Inventory.Repository.Paging;
using Inventory.ViewModel.BillViewModel;

namespace Inventory.Repository.BillTypeService
{
    public interface IBillTypeRepo
    {
        Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageNumber, int pageSize);

        Task Add(BillTypeListViewModel viewModel);

        Task Update(BillTypeListViewModel viewModel);

        Task Delete(int billTypeId);

        Task<BillTypeListViewModel> GetById(int billTypeId);
    }
}
