using Inventory.Repository.Paging;
using Inventory.ViewModel.CustomerViewModel;

namespace Inventory.Repository.CustomerService
{
    public interface ICustomerRepo
    {
        Task<PaginatedList<CustomerListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}
