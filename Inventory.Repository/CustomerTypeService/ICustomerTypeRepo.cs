using Inventory.Repository.Paging;
using Inventory.ViewModel.CustomerViewModel;

namespace Inventory.Repository.CustomerTypeService
{
    public interface ICustomerTypeRepo
    {
        Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}
